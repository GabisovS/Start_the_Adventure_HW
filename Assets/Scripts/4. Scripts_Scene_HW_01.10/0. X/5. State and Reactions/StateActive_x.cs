using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateActive_x : IBehaviour_x
{
    private const int _zeroAngle = 0;
    private const int _maxAngle = 90;

    private const float _time = 1;
    private float _currentTime;

    private Enemy_x _enemy;

    public StateActive_x(Enemy_x enemy)
    { 
        _enemy = enemy.GetComponent<Enemy_x>();
    }

    public void UpdateBehavior()
    {
        Move();
        Rotate();
        Debug.Log("random movement");
    }

    public void Move()
    {
        //_enemy.transform.Translate(Vector3.forward * Time.deltaTime * _enemy.Speed, Space.Self);
        _enemy.transform.Translate(Vector3.forward * Time.deltaTime * 25, Space.Self);
    }

    private void Rotate()
    {
        int _yAngle = Random.Range(_zeroAngle, _maxAngle);

        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
           // _enemy.transform.Rotate(new Vector3(_zeroAngle, _yAngle, _zeroAngle) * Time.deltaTime * _enemy.RotationSpeed);
            _enemy.transform.Rotate(new Vector3(_zeroAngle, _yAngle, _zeroAngle) * Time.deltaTime * 250);

            _currentTime = _time;

            Debug.Log(_yAngle);
        }
    }
}
