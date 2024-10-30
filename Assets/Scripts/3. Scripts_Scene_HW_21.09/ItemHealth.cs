using UnityEngine;

public class ItemHealth : Item
{
    [SerializeField] private int _healthUp;

    public override bool CanPickupFor(GameObject owner)
    {
        //return owner.GetComponentInChildren<Player>() != null;
        return owner != null;
    }
    public override void ApllyItemEffect(GameObject owner)
    {
        base.ApllyItemEffect(owner);

        Player player = owner.GetComponent<Player>();
        player.HealthSetUp( _healthUp);

        Debug.Log($"Item health is collect");
    }
}

