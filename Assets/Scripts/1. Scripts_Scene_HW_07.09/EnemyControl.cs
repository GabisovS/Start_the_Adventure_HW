using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minDistanceToTarget = 0.5f;

    [SerializeField] private List<Transform> _targets;

    private Queue<Vector3> _targetPositions;

    private Vector3 _currentTarget;

    void Awake()
    {
        TargetsToQue();
    }

/*    private void Update()
    {
        Movement();
    }*/

    private void TargetsToQue()
    {
        _targetPositions = new Queue<Vector3>();

        foreach (Transform target in _targets)
        {
            _targetPositions.Enqueue(target.position);
        }

        _currentTarget = _targetPositions.Dequeue();
    }

    public void Movement()
    {
        Vector3 direction = _currentTarget - transform.position;

        if (direction.magnitude <= _minDistanceToTarget)
        {
            SwitchTargets();
        }

        Vector3 normalizedDirection = direction.normalized;

        MoveToTargets(normalizedDirection);
        RotateToTarget(normalizedDirection);
    }


    private void MoveToTargets(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    private void RotateToTarget(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    private void SwitchTargets()
    {
        _targetPositions.Enqueue(_currentTarget);

        _currentTarget = _targetPositions.Dequeue();
    }

    public void ReloadTargetsQue()
    {
        _targetPositions = new Queue<Vector3>();

        foreach (Transform target in _targets)
        {
            _targetPositions.Enqueue(target.position);
        }

        _currentTarget = _targetPositions.Dequeue();
    }
}
