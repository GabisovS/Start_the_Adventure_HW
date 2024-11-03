using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActive : Enemy
{
    private const int _zeroAngle = 0;
    private const int _maxAngle = 90;

    private const float _time = 1;
    private float _currentTime;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed, Space.Self);

        Rotate();
    }

    private void Rotate()
    {
        int _yAngle = Random.Range(_zeroAngle, _maxAngle);

        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            transform.Rotate(new Vector3(_zeroAngle, _yAngle, _zeroAngle) * Time.deltaTime * RotationSpeed);

            _currentTime = _time;

            Debug.Log(_yAngle);
        }
    }
}
