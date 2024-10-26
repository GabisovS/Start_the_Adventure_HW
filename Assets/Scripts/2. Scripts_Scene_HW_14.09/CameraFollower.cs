using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private PlayerMovement _target;
    [SerializeField] private float _rotationSpeed;
    //[SerializeField] private Vector3 _offset;

    private string HorizontalInput = "Horizontal";

    private float _deadZone = 0.05f;
    private float _leftRightInput;


    private void Update()
    {
        _leftRightInput = Input.GetAxisRaw(HorizontalInput);
   
        transform.position = _target.transform.position;
               

        if (Mathf.Abs(_leftRightInput) > _deadZone)
        {
            MakeRotate();
        }
    }

    private void MakeRotate()
    {
        transform.Rotate(Vector3.up, _leftRightInput * _rotationSpeed * Time.deltaTime);
    }

}
