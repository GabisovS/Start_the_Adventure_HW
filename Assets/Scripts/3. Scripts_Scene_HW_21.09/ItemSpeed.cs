using UnityEngine;

public class ItemSpeed : Item
{
    [SerializeField] private int _speedUp;

    public override void ApllyItemEffect(Player player)
    {

        player.SpeedSetUp(_speedUp);

        Destroy(gameObject, 0.5f);

        Debug.Log($"Item health is collect {player.Speed}");

    }
}
