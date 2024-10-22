using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    public int CoinValue { get; private set; }

    public void SetCoinValue()
    { 
        CoinValue = Random.Range(_minValue, _maxValue);
    }

    public void MakeItActive()
    { 
        gameObject.SetActive(true);
    }
}
