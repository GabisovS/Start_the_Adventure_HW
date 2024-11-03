using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager_0110 : MonoBehaviour
{
    [SerializeField] private CharacterMovement _character;

    private bool _isRunning = false;


    void Start()
    {
        StartGame();
    }


    void Update()
    {
        if (_isRunning == false)
        {
            return;
        }

        _character.Movement();
    }

    private void StartGame()
    { 
        _isRunning = true;
    }
}
