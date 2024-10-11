using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ShurikenManager shurikenManager;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private int timeOfGame;
    [SerializeField] private int timeStepToIncreaseNumberOfShuriken;
    [SerializeField] private int stepOfIncreaseNumberOfShurikens;
    private int timeStepMultiplier = 1;
    private Ninja ninja;
    private Timer timer;

    public event Action TimeIsOver;
    public event Action NinjaIsLose;



    public Timer Timer => timer;
    public int TimeOfGame => timeOfGame;
    public CoinManager CoinManager => coinManager;
    public Ninja Ninja => ninja;

    private void OnEnable()
    {
        timeStepMultiplier = 1;
        shurikenManager.StartWork();
        coinManager.StartWork();
        timer.SetTimer(timeOfGame);
        timer.TimeIsOver += OnTimeIsOver;
        timer.TimeIsChanged += IncreaseNumberOfShurikens;
        timer.StartTimer();
        Ninja.NinjaIsCollideShureken += NinjaLose;
    }

    private void OnDisable()
    {
        shurikenManager.StopWork();
        coinManager.StopWork();
        timer.TimeIsOver -= OnTimeIsOver;
        timer.TimeIsChanged -= IncreaseNumberOfShurikens;
        timer.StopTimer();
        Ninja.NinjaIsCollideShureken -= NinjaLose;
    }

    private void OnTimeIsOver()
    {
        TimeIsOver?.Invoke();
        gameObject.SetActive(false);
    }

    private void NinjaLose()
    {
        NinjaIsLose?.Invoke();
        gameObject.SetActive(false);
    }

    private void IncreaseNumberOfShurikens(int currentTime)
    {
        if (timeOfGame - currentTime == timeStepMultiplier * timeStepToIncreaseNumberOfShuriken)
        {
            shurikenManager.IncreaseMaxNumberOfShurikens(stepOfIncreaseNumberOfShurikens);
            timeStepMultiplier++;
        }

    }

    void Awake()
    {
        timer = new Timer();
        gameObject.SetActive(false);
    }
}
