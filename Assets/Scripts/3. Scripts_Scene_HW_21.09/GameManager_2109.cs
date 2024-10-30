using TMPro;
using UnityEngine;

public class GameManager_2109 : MonoBehaviour
{
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _speed;

    [SerializeField] private ItemSpawner _spawner;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.InitInventory();
    }

    private void Update()
    {
        _spawner.SetSpawner();

        if (Input.GetKeyDown(KeyCode.F))
        {
            _player.UseItem();
        }

        _health.text = $"Health - {_player.Health}";
        _speed.text = $"Speed - {_player.Speed}";
    }

}
