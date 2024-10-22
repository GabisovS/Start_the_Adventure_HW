
using UnityEngine;

public class PlayerJumpConrol : MonoBehaviour
{

    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;

    private bool _isJumping;
    private bool _isOnGround = true;
    private bool _isOnAir = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _isJumping = Input.GetKeyDown(KeyCode.Space);
        _isOnGround = true;
        _isOnAir = false;
    }

    private void FixedUpdate()
    {

        //if (_isJumping && _isOnGround && _isOnAir)
        if (_isJumping && _isOnGround)
        {
            MakeJump();
            Debug.Log("Press Space");
        }
    }

    private void MakeJump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        _isOnGround = false;
        _isOnAir = true;
        Debug.Log("Jump");

    }

    private void OnCollisionStay(Collision collision)
    {
            _isOnGround = true;
            _isOnAir = false;

        Debug.Log("Collision");
    }
}
