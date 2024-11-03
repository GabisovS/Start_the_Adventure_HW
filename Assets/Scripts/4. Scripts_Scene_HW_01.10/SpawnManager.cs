using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private EnemySpawner _spawner;


    [SerializeField] private EnemyTypes _enemyTypes;
    [SerializeField] private ReactionTypes _actionTypes;



    private void Start()
    {
        _spawner.SpawnTo(_spawnPoint.position, _enemyTypes);
    }

}
