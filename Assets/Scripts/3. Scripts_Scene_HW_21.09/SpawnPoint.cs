using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Item _item;

    public bool IsEmpty
    {
        get 
        {
            if (_item == null)
                return true;

            else if (_item.gameObject == null)
                return true;

            return false;
        }
    }

    public Vector3 Position => transform.position;

    public void Occypy(Item item)
    {
        _item = item;
    }
}
