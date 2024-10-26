using TMPro;
using UnityEngine;

public class GameManager_2109 : MonoBehaviour
{
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _speed;
    [SerializeField] private TMP_Text _message;

    [SerializeField] private string _allert;

    [SerializeField] private ItemSpawner _spawner;
    [SerializeField] private ItemCollector _itemCollector;
    [SerializeField] private Player _player;


    private void Start()
    {
        _message.gameObject.SetActive(false);
    }
    private void Update()
    {
        _spawner.SetSpawner();
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_itemCollector.IsTakenItem)
            { 
                _itemCollector.UseItem();
                _message.gameObject.SetActive(false);
            }

            else
            {
                _message.text = $"{_allert}";
                _message.gameObject.SetActive(true);
            }
        }

        _health.text = $"Health - {_player.Health}";
        _speed.text = $"Speed - {_player.Speed}";
    }

}
