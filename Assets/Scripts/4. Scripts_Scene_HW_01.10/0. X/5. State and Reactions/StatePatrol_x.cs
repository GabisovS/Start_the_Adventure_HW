using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrol_x : IBehaviour_x
{
    private const int _speed = 25;
    private const int _rotationSpeed = 250;
    private const float _minDistanceToTarget = 0.5f;

    private Queue<Vector3> _targetPositions;

    private Vector3 _currentTarget;

    private Enemy_x _enemy;

    public StatePatrol_x(Enemy_x enemy, Queue<Vector3> targetPositions)
    {
        _enemy = enemy.GetComponent<Enemy_x>();
        _targetPositions = targetPositions;
        _currentTarget = _targetPositions.Dequeue();
    }

    public void UpdateBehavior()
    {
        
        Movement();
        Debug.Log("patrol the place");
    }

/*    public void TargetsToQue(List<Transform> targetsToPatrol)
    {
        // _targetsToPatrol = new List<Transform>(targetsToPatrol);
        _targetsToPatrol = targetsToPatrol;
        _targetPositions = new Queue<Vector3>();

        foreach (Transform target in _targetsToPatrol)
        {
            _targetPositions.Enqueue(target.position);
        }

        _currentTarget = _targetPositions.Dequeue();

    }*/


    private void Movement()
    {
        _currentTarget = _targetPositions.Dequeue();

        Vector3 direction = _currentTarget - _enemy.transform.position;

        if (direction.magnitude <= _minDistanceToTarget)
        {
            SwiTchTargets();
        }

        Vector3 normalizeDirection = direction.normalized;

        MoveToTarget(normalizeDirection);
        RotateToTarget(normalizeDirection);

        Debug.Log(_currentTarget);
    }

    private void SwiTchTargets()
    {
        _targetPositions.Enqueue(_currentTarget);
        _currentTarget = _targetPositions.Dequeue();
    }

    private void MoveToTarget(Vector3 direction)
    {
        _enemy.transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    private void RotateToTarget(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float step = _rotationSpeed * Time.deltaTime;

        _enemy.transform.rotation = Quaternion.RotateTowards(_enemy.transform.rotation, lookRotation, step);
    }
}
