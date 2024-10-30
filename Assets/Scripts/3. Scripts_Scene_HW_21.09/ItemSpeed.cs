using UnityEngine;

public class ItemSpeed : Item
{
    [SerializeField] private int _speedUp;

    public override bool CanPickupFor(GameObject owner)
    {
        return owner != null;
    }

    public override void ApllyItemEffect(GameObject owner)
    {
        base.ApllyItemEffect(owner);

        Player player = owner.GetComponent<Player>();
        player.SpeedSetUp(_speedUp);

        Debug.Log($"Item health is collect");
    }
}
