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


    void Start()
    {
        StartGame();
    }

    void Update()
    {
        RestartGame();

        if (_isRunning == false)
        {
            return;
        }

        _timer.SwitchOn();

        _player.Movement();
        _enemy.Movement();

        WinGame();
        LooseGame();
    }


    private void StartGame()
    {
        _isRunning = true;
        _position.StartPosition();

        _message.gameObject.SetActive(false);
    }

    private void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartGame();

            _enemy.ReloadTargetsQue();
            _timer.ResetTimer();
        }
    }

    private void WinGame()
    {
        if (_timer.CurrentTime <= _timeToWin)
        {
            _isRunning = false;

            _message.text = $"{_winMessage}";
            _message.gameObject.SetActive(true);
        }
    }

    private void LooseGame()
    {
        if (_distanceToLoose < _distance.Distance)
        {
            _isRunning = false;

            _message.text = $"{_looseMessage}";
            _message.gameObject.SetActive(true);
        }
    }
}
