using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemyControl _enemy;
    [SerializeField] private PlayerControl _player;
    [SerializeField] private DistanceDetector _distance;
    [SerializeField] private Position _position;
    [SerializeField] private Timer _timer;

    [SerializeField] private TMP_Text _message;

    [SerializeField] private string _looseMessage;
    [SerializeField] private string _winMessage;

    [SerializeField] private float _timeToWin;

    [SerializeField] private float _distanceToLoose;

    private bool _isRunning = false;


    private void Start()
    {
        StartGame();
        Debug.Log($"First Start Game: {_distanceToLoose} - {_distance.Distance}");
    }

    private void Update()
    {
        GameConditions();
        Debug.Log($"Update: {_distanceToLoose} - {_distance.Distance}");

        if (_isRunning == false)
        {
            return;
        }

        _timer.SwitchOn();

        _player.Movement();
        _enemy.Movement();

    }


    private void StartGame()
    {
        _isRunning = true;
        _position.StartPosition();

        _timer.SetTimer();

        _message.gameObject.SetActive(false);

        Debug.Log($"Start Game: {_distanceToLoose} - {_distance.Distance}");
    }

    private void GameConditions()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RestartGame();
            Debug.Log($"Pressed F: {_distanceToLoose} - {_distance.Distance}");
        }

        else if (_timer.CurrentTime <= _timeToWin)
        {
            WinGame();
            Debug.Log($"GameConditions Win: {_distanceToLoose} - {_distance.Distance}");
        }

        else if (_distanceToLoose < _distance.Distance)
        {
            LooseGame();
            Debug.Log($"GameConditions Loose: {_distanceToLoose} - {_distance.Distance}");
        }
    }

    private void RestartGame()
    {
        StartGame();

        _enemy.TargetsToQue();
        _timer.SetTimer();
        Debug.Log("Restart Game");
    }

    private void WinGame()
    {
        _isRunning = false;

        _message.text = $"{_winMessage}";
        _message.gameObject.SetActive(true);
        Debug.Log($"WinGame: {_distanceToLoose} - {_distance.Distance}");
    }

    private void LooseGame()
    {
        _isRunning = false;

        _message.text = $"{_looseMessage}";
        _message.gameObject.SetActive(true);

        Debug.Log($"LooseGame: {_distanceToLoose} - {_distance.Distance}");
    }
}
