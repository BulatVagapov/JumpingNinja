using DG.Tweening;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    [SerializeField] private Vector2 movementDirection;
    [SerializeField] private float speed;
    [SerializeField] private Transform visualPart;
    private Rigidbody2D shurikenRB;
    public ShurikenManager ShurikenManager;

    private bool positionforSpawnCoinIsAdded;

    private int randomForX;
    private int randomForY;

    void Awake()
    {
        shurikenRB = GetComponent<Rigidbody2D>();
        visualPart.DORotate(-Vector3.forward * 360, 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);

    }

    private void OnEnable()
    {
        randomForX = Random.Range(0, 2);
        randomForY = Random.Range(0, 2);

        movementDirection.x = randomForX == 0 ? -1 : 1;
        movementDirection.y = randomForY == 0 ? -1 : 1;

        shurikenRB.velocity = movementDirection * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            movementDirection.y = 1;
        }else if(collision.gameObject.CompareTag("Top"))
        {
            movementDirection.y = -1;
        }else if(collision.gameObject.CompareTag("Left"))
        {
            movementDirection.x = 1;
        }
        else if (collision.gameObject.CompareTag("Right"))
        {
            movementDirection.x = -1;
        }

        shurikenRB.velocity = movementDirection * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ninja") && !positionforSpawnCoinIsAdded)
        {
            ShurikenManager.AddPositionForSpawnCoin(transform);
            positionforSpawnCoinIsAdded = true;
        }

    }

    private void OnDisable()
    {
        positionforSpawnCoinIsAdded = false;
    }

}
