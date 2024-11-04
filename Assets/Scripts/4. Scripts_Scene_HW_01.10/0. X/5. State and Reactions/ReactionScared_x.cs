using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionScared_x : IBehaviour_x
{
    private Enemy_x _enemy;

    public ReactionScared_x(Enemy_x enemy)
    {
        _enemy = enemy.GetComponent<Enemy_x>();
    }

    public void UpdateBehavior()
    {
        _enemy.gameObject.SetActive(false);
        Debug.Log("scared and destroyed");
    }

 }
