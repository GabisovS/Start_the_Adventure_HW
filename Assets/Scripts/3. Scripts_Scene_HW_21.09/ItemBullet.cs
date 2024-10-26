using UnityEngine;

public class ItemBullet : Item
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _force;


    public override void ApllyItemEffect(Player player)
    {
        _rigidbody.AddForce(Vector3.forward * _force, ForceMode.Impulse);
        Destroy(gameObject, 3f);
        Debug.Log("Item bullet is apllied");
  
    }
}
