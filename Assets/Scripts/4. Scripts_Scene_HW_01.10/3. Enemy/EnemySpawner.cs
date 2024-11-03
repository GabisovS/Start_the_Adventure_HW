using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetsToPatrol;

    [SerializeField] private Enemy _enemyStaticPrefab;
    [SerializeField] private EnemyPatrol _enemyPatrolPrefab;
    [SerializeField] private Enemy _enemyActivePrefab;

    private void Awake()
    {
        _enemyPatrolPrefab.TargetsToQue(_targetsToPatrol);
    }

    public void SpawnTo(Vector3 position, EnemyTypes enemyType)
    {
        switch (enemyType)
        {
            case EnemyTypes.Static:
                Instantiate(_enemyStaticPrefab, position, Quaternion.identity, null);
                break;

            case EnemyTypes.Patrol:
                
                Instantiate(_enemyPatrolPrefab, position, Quaternion.identity, null);
                //_enemyPatrolPrefab.TargetsToQue();
                break;

            case EnemyTypes.Active:
                Instantiate(_enemyActivePrefab, position, Quaternion.identity, null);
                break;

            default:
                Debug.LogError("Not right type of enemy");
                break;
        }
    }
}
