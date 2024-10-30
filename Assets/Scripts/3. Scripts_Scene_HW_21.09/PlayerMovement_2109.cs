using UnityEngine;

public class PlayerMovement_2109 : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Player _player;

    [SerializeField] private float _rotationSpeed;

    private string HorizontalInput = "Horizontal";
    private string VerticalInput = "Vertical";

    private float _forwardInput;
    private float _leftRightInput;
    private float _deadZone = 0.05f;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _forwardInput = Input.GetAxisRaw(VerticalInput);
        _leftRightInput = Input.GetAxisRaw(HorizontalInput);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_forwardInput) > _deadZone || Mathf.Abs(_leftRightInput) > _deadZone)
        {
            MakeMove();
            MakeRotation();
        }
    }
    private void MakeMove()
    {
        _rigidbody.AddRelativeForce(Vector3.forward.normalized * _player.Speed * _forwardInput, ForceMode.Acceleration);
    }

    private void MakeRotation()
    {
        _rigidbody.AddTorque(Vector3.up * _rotationSpeed * _leftRightInput);
    }
}
