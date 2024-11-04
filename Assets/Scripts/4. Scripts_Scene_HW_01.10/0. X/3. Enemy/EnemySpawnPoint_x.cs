using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint_x : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private EnemySpawner_x _spawner;

    public EnemyTypes_x EnemyTypes;
    public StateTypes_x StateTypes;
    public ReactionTypes_x ReactionTypes;
}
