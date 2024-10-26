using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _wallet;
    private int _zeroItems = 0;
    public int TotalItems { get; private set; }

    public void CollectItems(int value)
    { 
        TotalItems += value;

        _wallet.text = TotalItems.ToString();
    }

    public void ResetWallet()
    { 
        TotalItems = _zeroItems;
        _wallet.text = TotalItems.ToString();
    }
}
