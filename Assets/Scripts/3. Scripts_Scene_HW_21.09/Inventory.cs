using UnityEngine;

public class Inventory
{
    private Transform _itemPosition;
    private Item _item;

    public Inventory(Transform itemPosition)
    { 
        _itemPosition = itemPosition;
    }
    public bool HasItem() => _item != null; //проверка на наличие Item в инвентаре

    public Item GetItem() // забюираем Item из инвенторя
    {
        if (HasItem() == false)
        {
            Debug.LogError("Нет предмета");
            return null;
        }

        _item.transform.SetParent(null); //убираем Item из точки крепления
        Item selectedItem = _item; //присваеваем ссылку взятому Item 
        _item = null; // зануляем ссылку
        return selectedItem; // вовзращаем взятый Item
    }

    public void PutItem(Item item)
    {
        if (HasItem())
        {
            Debug.LogError("Уже есть предмет");
            return;
        }

        _item = item;

        _item.transform.SetParent(_itemPosition);
        _item.transform.localPosition = Vector3.zero;
    }
}
