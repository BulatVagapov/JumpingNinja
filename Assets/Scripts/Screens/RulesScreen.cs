using UnityEngine;
using UnityEngine.UI;

public class RulesScreen : AbstractScreen
{
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private Button okButton;
    [SerializeField] private Button crossButton;
    [SerializeField] private GameObject gameManager;
    
    void Start()
    {
        gameScreen.SetActive(false);
        okButton.onClick.AddListener(() => OnOkButtonClick());
        crossButton.onClick.AddListener(() => ChangeScreen(mainMenuScreen));
    }

    private void OnOkButtonClick()
    {
        ChangeScreen(gameScreen);
        gameManager.SetActive(true);
    }
}
