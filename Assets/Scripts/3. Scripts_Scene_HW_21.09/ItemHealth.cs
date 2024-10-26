using UnityEngine;

public class ItemHealth : Item
{
    [SerializeField] private int _healthUp;

    public override void ApllyItemEffect(Player player)
    {

        player.HealthSetUp( _healthUp);

        Destroy(gameObject, 0.5f);

        Debug.Log($"Item health is collect {player.Health}");
    
    }
}
