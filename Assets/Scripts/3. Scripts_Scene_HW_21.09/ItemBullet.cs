using UnityEngine;

public class ItemBullet : Item
{
    [SerializeField] private Bullet _bulletPrefab;

    public override bool CanPickupFor(GameObject owner)
    {
        //return owner.GetComponentInChildren<ShootPoint>() != null;
        return owner != null;
    }
    public override void ApllyItemEffect(GameObject owner)
    {
        base.ApllyItemEffect(owner); //вызываем партикл эфф из родительского класса

        Transform shootPoint = owner.GetComponentInChildren<ShootPoint>().transform;

        Bullet bullet = Instantiate(_bulletPrefab, shootPoint.position, Quaternion.identity, null);

        bullet.Launch(shootPoint.forward);

        Debug.Log("Item bullet is apllied");
    }
}

