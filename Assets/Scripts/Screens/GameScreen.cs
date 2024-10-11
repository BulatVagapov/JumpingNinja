using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Slider timeSlider;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.Timer.TimeIsChanged += TimeIsChanged;
        gameManager.CoinManager.NumberOfCoinsIsChanged += (value) => scoreText.text = value.ToString();
    }

    private void TimeIsChanged(int currentTime)
    {
        timeText.text = currentTime.ToString();

        timeSlider.value = (float)currentTime / (float)gameManager.TimeOfGame;
    }

}
