using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField] private ItemCollector _itemcollector;

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();

        if (item != null)
        { 
            if (_itemcollector.IsTakenItem == false)
            {  
                _itemcollector.CollectItem(item);

                Debug.Log("Triger detection");
            }
        }
    }
}
