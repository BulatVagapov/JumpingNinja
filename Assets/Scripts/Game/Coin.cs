using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinManager CoinManager;
    [SerializeField] private int numberOfCoins;
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ninja")) return;

        CoinManager.AddCoin(numberOfCoins);
        CoinManager.ReturnCoinToPool(this);
    }
}
