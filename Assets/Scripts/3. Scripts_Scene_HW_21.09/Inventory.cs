using UnityEngine;

public class Inventory
{
    private Transform _itemPosition;
    private Item _item;

    public Inventory(Transform itemPosition)
    { 
        _itemPosition = itemPosition;
    }
    public bool HasItem() => _item != null; //�������� �� ������� Item � ���������

    public Item GetItem() // ��������� Item �� ���������
    {
        if (HasItem() == false)
        {
            Debug.LogError("��� ��������");
            return null;
        }

        _item.transform.SetParent(null); //������� Item �� ����� ���������
        Item selectedItem = _item; //����������� ������ ������� Item 
        _item = null; // �������� ������
        return selectedItem; // ���������� ������ Item
    }

    public void PutItem(Item item)
    {
        if (HasItem())
        {
            Debug.LogError("��� ���� �������");
            return;
        }

        _item = item;

        _item.transform.SetParent(_itemPosition);
        _item.transform.localPosition = Vector3.zero;
    }
}
