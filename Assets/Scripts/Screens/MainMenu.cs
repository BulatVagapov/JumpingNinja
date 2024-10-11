using UnityEngine;
using UnityEngine.UI;

public class MainMenu : AbstractScreen
{
    [SerializeField] private GameObject roolesScreen;
    [SerializeField] private GameObject personalizationScreen;
    [SerializeField] private GameObject optionsScreen;

    [SerializeField] private Button playButton;
    [SerializeField] private Button personalizationButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;

    void Start()
    {
        roolesScreen.SetActive(false);
        personalizationScreen.SetActive(false);
        optionsScreen.SetActive(false);

        playButton.onClick.AddListener(() => ChangeScreen(roolesScreen));
        personalizationButton.onClick.AddListener(() => ChangeScreen(personalizationScreen));
        optionsButton.onClick.AddListener(() => ChangeScreen(optionsScreen));
        exitButton.onClick.AddListener(() => Application.Quit());

        gameObject.SetActive(false);
    }
}
