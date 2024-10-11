using UnityEngine;

public abstract class AbstractScreen : MonoBehaviour
{
    protected void ChangeScreen(GameObject screen)
    {
        gameObject.SetActive(false);
        screen.SetActive(true);
    }    
}
