using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameManager2 _gameManager;

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();

        if (coin != null)
        {
            coin.SetCoinValue();
            _wallet.CollectItems(coin.CoinValue);
            _gameManager.ItemColletorToWin();

            coin.gameObject.SetActive(false);
        }
    }


}
