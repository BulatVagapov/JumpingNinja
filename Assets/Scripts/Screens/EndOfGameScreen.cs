using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGameScreen : AbstractScreen
{
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button menuButton;

    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text coinCountText;

    [SerializeField] private GameManager gameManager;

    private string timeIsUp = "TIME’S UP";
    private string youLose = "YOU LOST";

    void Awake()
    {
        gameObject.SetActive(false);
        gameManager.TimeIsOver += TimeIsUp;
        gameManager.NinjaIsLose += Lose;

        RestartButton.onClick.AddListener(() => ChangeScreen(gameScreen));
        RestartButton.onClick.AddListener(() => RestartGame());
        menuButton.onClick.AddListener(() => ChangeScreen(mainMenuScreen));
    }

    private void RestartGame()
    {
        gameManager.gameObject.SetActive(true);
        NinjaManager.Instance.RestartNinja();
    }

    private void TimeIsUp()
    {
        resultText.text = timeIsUp;
        coinCountText.text = gameManager.CoinManager.NumberOfCoin.ToString();
        gameScreen.SetActive(false);
        gameObject.SetActive(true);
    }

    private void Lose()
    {
        resultText.text = youLose;
        coinCountText.text = gameManager.CoinManager.NumberOfCoin.ToString();
        gameScreen.SetActive(false);
        gameObject.SetActive(true);
    }
}
