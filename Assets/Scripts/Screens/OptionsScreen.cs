using UnityEngine;
using UnityEngine.UI;

public class OptionsScreen : AbstractScreen
{
    [SerializeField] private GameObject privatePolicyScreen;
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private Button privatePolicyButton;
    [SerializeField] private Button crossButton;
    [SerializeField] private Button musicButton;

    [SerializeField] private AudioSource music;
    [SerializeField] private Image musicImage;

    // Start is called before the first frame update
    void Start()
    {
        privatePolicyScreen.SetActive(false);
        privatePolicyButton.onClick.AddListener(() => ChangeScreen(privatePolicyScreen));
        crossButton.onClick.AddListener(() => ChangeScreen(mainMenuScreen));
        musicButton.onClick.AddListener(() => SetMusic());

        gameObject.SetActive(false);
    }

    private void SetMusic()
    {
        if (music.isPlaying)
        {
            music.Stop();
            musicImage.color = Color.black;
        }
        else
        {
            music.Play();
            musicImage.color = Color.white;
        }
    }
}
