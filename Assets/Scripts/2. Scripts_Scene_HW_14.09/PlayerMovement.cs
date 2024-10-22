using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody _rigidbody;

    private string HorizontalInput = "Horizontal";
    private string VerticalInput = "Vertical";

    private float _leftRightInput;
    private float _forwardInput;
    private float _deadZone = 0.05f;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _leftRightInput = Input.GetAxisRaw(HorizontalInput);
        _forwardInput = Input.GetAxisRaw(VerticalInput);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_leftRightInput) > _deadZone)
        {
            MakeRotate();
        }

        if (Mathf.Abs(_forwardInput) > _deadZone)
        {
            MakeMove();
        }
    }

    private void MakeRotate()
    {
        _rigidbody.AddForce(Vector3.right * _rotationSpeed * _leftRightInput, ForceMode.Acceleration);
    }

    private void MakeMove()
    {
        _rigidbody.AddForce(Vector3.forward * _speed * _forwardInput, ForceMode.Acceleration);
    }

}
