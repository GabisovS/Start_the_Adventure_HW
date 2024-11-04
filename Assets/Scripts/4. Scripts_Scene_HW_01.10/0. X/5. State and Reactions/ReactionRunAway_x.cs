using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionRunAway_x : IBehaviour_x
{
    private const int _speed = 25;
    private const int _rotationSpeed = 250;

    private Character_x _character;
    private Enemy_x _enemy;

    public ReactionRunAway_x(Enemy_x enemy, Character_x character)
    {
        _enemy = enemy.GetComponent<Enemy_x>();
        _character = character.GetComponent<Character_x>();
    }

    public void UpdateBehavior()
    {
        Move();
        Debug.Log("trying to run away from player");
    }

    private void Move()
    {
        Vector3 direction = _enemy.transform.position - _character.transform.position;
        

        Vector3 normalizeDirection = direction.normalized;

        _enemy.transform.Translate(normalizeDirection * _speed * Time.deltaTime, Space.World);
    }
}
