using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy
{
    //[SerializeField] private List<Transform> _targetsInList;

    private const float _minDistanceToTarget = 0.5f;

    private List<Transform> _targetsToPatrol;

    private Queue<Vector3> _targetPositions;

    private Vector3 _currentTarget;


/*    public void Init(List<Transform> targetsToPatrol)
    {
        _targetsToPatrol = new List<Transform>(targetsToPatrol);
    }*/

    public void TargetsToQue(List<Transform> targetsToPatrol)
    {
        _targetsToPatrol = new List<Transform>(targetsToPatrol);
        _targetPositions = new Queue<Vector3>();

        foreach (Transform target in _targetsToPatrol)
        {
            _targetPositions.Enqueue(target.position);
        }

        _currentTarget = _targetPositions.Dequeue();
        
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 direction = _currentTarget - transform.position;

        if (direction.magnitude <= _minDistanceToTarget)
        {
            SwiTchTargets();
        }

        Vector3 normalizeDirection = direction.normalized;

        MoveToTarget(normalizeDirection);
        RotateToTarget(normalizeDirection);
    }

    private void SwiTchTargets()
    {
        _targetPositions.Enqueue(_currentTarget);
        _currentTarget = _targetPositions.Dequeue();
    }

    private void MoveToTarget(Vector3 direction)
    {
        transform.Translate(direction * Speed * Time.deltaTime, Space.World);
    }

    private void RotateToTarget(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float step = RotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }
}
