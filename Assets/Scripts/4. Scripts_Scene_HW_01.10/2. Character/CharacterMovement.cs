using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Character _character;

    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";

    private const float _deadZone = 0.05f;
    private const float _yAxis = 0f;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Movement()
    {
        Vector3 userInput = new Vector3(Input.GetAxisRaw(HorizontalInput), _yAxis, Input.GetAxisRaw(VerticalInput));

        if (userInput.magnitude <= _deadZone)
        {
            return;
        }

        _characterController.Move(userInput * _character.Speed * Time.deltaTime);

        Rotation(userInput);
    }

    private void Rotation(Vector3 direction)
    { 
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float step = _character.RotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}

