using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    [SerializeField] private Transform _hero;
    [SerializeField] private Transform _enemy;

    [SerializeField] private Vector3 _startPositionHero;
    [SerializeField] private Vector3 _startPositionEnemy;


    public void StartPosition()
    {
        _hero.position = _startPositionHero;
        _enemy.position = _startPositionEnemy;
    }
}
