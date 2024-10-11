using System;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    public float MovementDirectionX;
    public bool JumpComand;

    private bool isGrounded;
    private bool eventIsInvoked;
    private Vector2 movementDirection = Vector2.zero;

    public static event Action NinjaIsGrounded;
    public static event Action NinjaIsCollideShureken;

    private void FixedUpdate()
    {
        movementDirection.x = MovementDirectionX * speed;
        movementDirection.y = rigidbody.velocity.y;
        rigidbody.velocity = movementDirection;

        if (JumpComand)
        {
            Jump();
            JumpComand = false;
        }

    }

    private void Jump()
    {
        if (!isGrounded) return;

        rigidbody.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ground")) return;

        isGrounded = true;

        if (!eventIsInvoked)
        {
            NinjaIsGrounded?.Invoke();
            eventIsInvoked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ground")) return;

        isGrounded = false;
        eventIsInvoked = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shuriken"))
        {
            NinjaIsCollideShureken?.Invoke();
        }

    }

    public void StopNinja()
    {
        rigidbody.velocity = Vector2.zero;
    }
}
