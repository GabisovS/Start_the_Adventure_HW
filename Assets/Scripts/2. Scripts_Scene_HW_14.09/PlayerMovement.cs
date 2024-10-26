using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CameraFollower _camera;

    [SerializeField] private float _speed;
   //[SerializeField] private float _rotationSpeed;

    private Rigidbody _rigidbody;

    //private string HorizontalInput = "Horizontal";
    private string VerticalInput = "Vertical";

    //public float LeftRightInput { get; private set; }
    private float _forwardInput;
    private float _deadZone = 0.05f;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //DisableKinematic();
    }

    private void Update()
    {
       // LeftRightInput = Input.GetAxisRaw(HorizontalInput);
        _forwardInput = Input.GetAxisRaw(VerticalInput);
    }

    private void FixedUpdate()
    {
/*        if (Mathf.Abs(LeftRightInput) > _deadZone)
        {
            MakeRotate();
        }*/

        if (Mathf.Abs(_forwardInput) > _deadZone)
        {
            MakeMove();
        }
    }

/*    private void MakeRotate()
    {
        //_rigidbody.AddTorque(Vector3.up * _rotationSpeed * LeftRightInput);
    }*/

    private void MakeMove()
    {
        //_rigidbody.AddForce(Vector3.forward * _speed * _forwardInput, ForceMode.Acceleration);
        _rigidbody.AddForce(_camera.transform.forward * _speed * _forwardInput);
    }

    public void EnableKinematic()
    {
        _rigidbody.isKinematic = true;
    }

    public void DisableKinematic()
    {
        _rigidbody.isKinematic = false;
    }

}
