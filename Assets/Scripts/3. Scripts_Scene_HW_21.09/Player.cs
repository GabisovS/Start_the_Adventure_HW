using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private ItemCollector _itemCollector;
    [SerializeField] private Transform _itemPosition;

    [SerializeField] private TMP_Text _message;
    [SerializeField] private string _allert;

    [SerializeField] private int _health;
    [SerializeField] private int _speed;

    private ItemHandler _itemHandler;

    public int Health { get => _health; private set => _health = value; }
    public int Speed { get => _speed; private set => _speed = value; }

    private void Start()
    {
        _message.gameObject.SetActive(false);
    }

    public void InitInventory()
    {
        Inventory inventory = new Inventory(_itemPosition);

        _itemCollector.Initialize(inventory);
        _itemHandler = new ItemHandler(inventory, gameObject);
    }

    public void UseItem()
    {
        if (_itemHandler.CanUseItem())
        {
            _itemHandler.UseItem();
            _message.gameObject.SetActive(false);
        }

        else
        {
            _message.text = $"{_allert}";
            _message.gameObject.SetActive(true);
        }
    }

    public void HealthSetUp(int value)
    {
        Health += value;

        if (Health < 0)
        {
            Health = 0;
        }

        Debug.Log($"Current {Health}");
    }

    public void SpeedSetUp(int value)
    {
        Speed += value;

        if (Speed < 0)
        {
            Speed = 0;
        }
        Debug.Log($"Current {Speed}");
    }
}
