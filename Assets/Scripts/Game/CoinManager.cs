using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private List<Coin> coins;
    [SerializeField] private Coin coinPrefab;

    private int numberOfCoins;
    [SerializeField] private int totalNumberOfCoins;
    public int NumberOfCoin => numberOfCoins;
    public int TotalNumberOfCoins => totalNumberOfCoins;

    public event Action<int> NumberOfCoinsIsChanged;


    void Awake()
    {
        coins = transform.GetComponentsInChildren<Coin>().ToList();
        foreach (Coin coin in coins)
        {
            coin.CoinManager = this;
            coin.gameObject.SetActive(false);
        }
    }

    public void StopWork()
    {
        totalNumberOfCoins += numberOfCoins;
    }

    public void StartWork()
    {
        if (coins != null)
        {
            foreach (Coin coin in coins)
            {
                coin.gameObject.SetActive(false);
            }
        }

        numberOfCoins = 0;
        NumberOfCoinsIsChanged?.Invoke(numberOfCoins);
    }

    public void AddCoin(int additionalNumberOfCoin)
    {
        numberOfCoins += additionalNumberOfCoin;
        NumberOfCoinsIsChanged?.Invoke(numberOfCoins);
    }

    public void SpawnCoin(Vector2 spawnPosition)
    {
        for(int i = 0; i < coins.Count; i++)
        {
            if (!coins[i].gameObject.activeSelf)
            {
                coins[i].transform.position = spawnPosition;
                coins[i].gameObject.SetActive(true);
                break;
            }

            if(i == coins.Count - 1)
            {
                Coin additionalCoin = Instantiate(coinPrefab, this.transform);
                additionalCoin.CoinManager = this;
                additionalCoin.transform.position = spawnPosition;
                coins.Add(additionalCoin);
            }
        }
    }

    public void ReturnCoinToPool(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }
}
