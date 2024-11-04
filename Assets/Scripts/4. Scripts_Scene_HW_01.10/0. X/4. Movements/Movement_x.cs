using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Movement_x : MonoBehaviour
{


/*    public void Movement()
    {
        Vector3 userInput = new Vector3(Input.GetAxisRaw(HorizontalInput), _yAxis, Input.GetAxisRaw(VerticalInput));

        if (userInput.magnitude <= _deadZone)
        {
            return;
        }

        _characterController.Move(userInput * _character.Speed * Time.deltaTime);
    }
*/
    public void Rotation(Vector3 direction, int rotationSpeed)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float step = rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

}
