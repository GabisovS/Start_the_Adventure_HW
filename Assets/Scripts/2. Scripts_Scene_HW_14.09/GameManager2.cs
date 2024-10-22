using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Timer_2 _timer;
    [SerializeField] private Wallet _wallet;

    [SerializeField] private TMP_Text _message;
    [SerializeField] private TMP_Text _items;

    [SerializeField] private Transform _rotatePointStartPosition;
    [SerializeField] private PlayerMovement _playerStartPosition;

    [SerializeField] private string _looseMessage;
    [SerializeField] private string _winMessage;

    [SerializeField] private float _timeToLoose;
    [SerializeField] private float _totalItemToWin;
    [SerializeField] private int _startItemsValue;

    public int TotalItems { get; private set; }

    private bool _isRunning = false;


    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        GameConditions();

        if (_isRunning == false)
        {
            return;
        }

        _timer.SwitchOn();
    }


    private void StartGame()
    {
        _isRunning = true;

        _timer.SetTime();
        _playerStartPosition.DisableKinematic();
        

        SetStartPosition();
        
        _message.gameObject.SetActive(false);
    }

    private void GameConditions()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            _playerStartPosition.EnableKinematic();
            RestartGame();

            Time.timeScale = 1;
        }

        else if (TotalItems >= _totalItemToWin)
        {
            WinGame();
            Time.timeScale = 0;
        }

        else if (_timer.CurrentTime <= _timeToLoose)
        {
            LooseGame();
            Time.timeScale = 0;
        }
    }

    private void RestartGame()
    {
        StartGame();

        _coinPrefab.SetActive(true);
        _timer.SetTime();
        _wallet.ResetWallet();

        TotalItems = _startItemsValue;

        _items.text = TotalItems.ToString();
    }

    private void WinGame()
    {
        _isRunning = false;

        _message.text = $"{_winMessage}";
        _message.gameObject.SetActive(true);
    }

    private void LooseGame()
    {
        _isRunning = false;

        _message.text = $"{_looseMessage}";
        _message.gameObject.SetActive(true);
    }

    public void ItemColletorToWin()
    {
        TotalItems++;
        _items.text = TotalItems.ToString();
    }

    private void SetStartPosition()
    {
        _rotatePointStartPosition.position = Vector3.zero;
        _rotatePointStartPosition.rotation = Quaternion.identity;

        _playerStartPosition.transform.position = Vector3.zero;
        _playerStartPosition.transform.rotation = Quaternion.identity;
    }
}
