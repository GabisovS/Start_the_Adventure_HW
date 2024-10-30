using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private Inventory _inventory;

    public void Initialize(Inventory inventory)
    { 
        _inventory  = inventory;
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();

        if (item == null)
        {
            return;
        }

        if (CanPickupItem(item))
        {
            _inventory.PutItem(item);
        }
    }

    private bool CanPickupItem(Item item)
    {
        return _inventory.HasItem() == false && item.CanPickupFor(gameObject);
    }
}
