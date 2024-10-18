using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private string HorizontalInput = "Horizontal";
    private string VerticalInput = "Vertical";

    private float _deadZone = 0.01f;

    private CharacterController _characterController;


    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

/*    void Update()
    {
        Movement();
    }*/

    public void Movement()
    {
        Vector3 UserInput = new Vector3(Input.GetAxisRaw(HorizontalInput), 0, Input.GetAxisRaw(VerticalInput));

        if (UserInput.magnitude <= _deadZone)
        {
            return;
        }

        _characterController.Move(UserInput.normalized * _speed * Time.deltaTime);

        Rotation(UserInput);
    }

    private void Rotation(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

}
