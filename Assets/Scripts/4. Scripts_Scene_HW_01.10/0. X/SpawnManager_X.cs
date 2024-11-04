using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_X : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetsToPatrol;

    [SerializeField] private List<EnemySpawnPoint_x> _spawnPoints;
    [SerializeField] private EnemySpawner_x _spawner;
    [SerializeField] private Character_x _character;

    private Queue<Vector3> _targetToPatrolPositions;

    private Vector3 _currentTarget;

    private void Awake()
    {
        foreach (EnemySpawnPoint_x spawnPoint in _spawnPoints)
        {
            Spawn(spawnPoint);
        }

        TargetsToQue();
    }

    private void Spawn(EnemySpawnPoint_x spawnPoint)
    {
        Enemy_x _enemy = _spawner.EnemySpawnTo(spawnPoint.transform.position, spawnPoint.EnemyTypes);

        _enemy.Init(StateSetUp(spawnPoint.StateTypes, _enemy), ReactionSetUp(spawnPoint.ReactionTypes, _enemy)); 
    }

    private void TargetsToQue()
    {
        _targetToPatrolPositions = new Queue<Vector3>();
        // из списка _targets добавляется в очередь каждая точка
        foreach (Transform target in _targetsToPatrol)
        {
            _targetToPatrolPositions.Enqueue(target.position);
        }
      
        //из очереди забирается позиция первой точки _target
        _currentTarget = _targetToPatrolPositions.Dequeue();
    }

    private IBehaviour_x StateSetUp(StateTypes_x stateType, Enemy_x enemy)
    {
        switch (stateType)
        {
            case StateTypes_x.Idle:
                return new StateIdle_x();
                break;

            case StateTypes_x.Active:
                return new StateActive_x(enemy);
                break;

            case StateTypes_x.Patrol:
                return new StatePatrol_x(enemy, _targetToPatrolPositions);
                break;
        }
        return null;
    }

    private IBehaviour_x ReactionSetUp(ReactionTypes_x reactionType, Enemy_x enemy)
    {
        switch (reactionType)
        {
            case ReactionTypes_x.RunAway:
                return new ReactionRunAway_x(enemy, _character);
                break;

            case ReactionTypes_x.CatchUp:
                return new ReactionCatchUp_x(enemy, _character);
                break;

            case ReactionTypes_x.Scared:
                return new ReactionScared_x(enemy);
                break;
        }
        return null;
    }
}
