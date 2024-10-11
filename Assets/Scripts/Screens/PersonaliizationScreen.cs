using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonaliizationScreen : AbstractScreen
{
    [SerializeField] private Button crossButton;
    [SerializeField] private GameObject backScreen;

    [SerializeField] private ChoseNinjaButton[] choseNinjaButtons;
    [SerializeField] private CoinManager coinManager;

    private bool buttonsIsInited;

    void Start()
    {
        crossButton.onClick.AddListener(() => ChangeScreen(backScreen));
        for (int i = 0; i < choseNinjaButtons.Length; i++)
        {
            choseNinjaButtons[i].InitButton();
        }
        buttonsIsInited = true;

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (!buttonsIsInited) return;

        for (int i = 0; i < choseNinjaButtons.Length; i++)
        {
            if (choseNinjaButtons[i].NinjaPrice <= coinManager.TotalNumberOfCoins || NinjaManager.Instance.OpenedNinjas.OpenedNinjas[i])
            {
                choseNinjaButtons[i].Button.interactable = true;
            }
            else
            {
                choseNinjaButtons[i].Button.interactable = false;
            }
        }
    }
}
