using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_x : MonoBehaviour
{
    [SerializeField] private Character_x _character;

    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    private const float _deadZone = 0.05f;
    private const float _yAxis = 0f;

    private CharacterController _characterController;
    private Movement_x _movement;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _movement = GetComponent<Movement_x>();
    }

    public void Update()
    {
        Vector3 userInput = new Vector3(Input.GetAxisRaw(HorizontalInput), _yAxis, Input.GetAxisRaw(VerticalInput));
        
        Movement(userInput);
        _movement.Rotation(userInput, _character.RotationSpeed);
    }

    public void Movement(Vector3 direction)
    {
        Vector3 userInput = new Vector3(Input.GetAxisRaw(HorizontalInput), _yAxis, Input.GetAxisRaw(VerticalInput));

        if (userInput.magnitude <= _deadZone)
        {
            return;
        }

        _characterController.Move(userInput * _character.Speed * Time.deltaTime);
    }
}
