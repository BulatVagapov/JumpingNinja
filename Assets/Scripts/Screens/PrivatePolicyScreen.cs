using UnityEngine;
using UnityEngine.UI;

public class PrivatePolicyScreen : AbstractScreen
{
    [SerializeField] private Button crossButton;
    [SerializeField] private GameObject backScreen;
    
    void Start()
    {
        crossButton.onClick.AddListener(() => ChangeScreen(backScreen));

        gameObject.SetActive(false);
    }
}
