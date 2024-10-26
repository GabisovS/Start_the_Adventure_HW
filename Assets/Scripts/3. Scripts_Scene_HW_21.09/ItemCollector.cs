using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _itemPosition;

    private List<Item> _itemList;

    public bool IsTakenItem
    {
        get;
        private set;
    }


    public void CollectItem(Item item)
    {
        Item itemClone = Instantiate(item, _itemPosition.position, item.transform.rotation, null);
        Destroy(item.gameObject);

        _itemList.Add(itemClone);

        IsTakenItem = true;

    }

    public void UseItem()
    {
        _itemList[0].ApllyItemEffect(_player);

        //Destroy(_itemList[0].gameObject); Объект ItemBullet не отыгрывает свой эффект

        _itemList.Remove(_itemList[0]);

        IsTakenItem = false;
    }

}
