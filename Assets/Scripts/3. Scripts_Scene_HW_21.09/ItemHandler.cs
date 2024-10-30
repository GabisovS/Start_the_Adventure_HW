using UnityEngine;

public class ItemHandler
{
    private Inventory _inventory;
    private GameObject _owner;

    public ItemHandler(Inventory inventory, GameObject owner)
    {
        _inventory = inventory;
        _owner = owner;
    }

    public bool CanUseItem() => _inventory.HasItem();

    public void UseItem()
    {
        if (CanUseItem() == false)
        {
            Debug.LogError("Нельзя использовать предмет");
            return;
        }

        Item item = _inventory.GetItem();
        item.ApllyItemEffect(_owner);
        Object.Destroy(item.gameObject);
    }
}
