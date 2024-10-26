using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _speed;
    public int Health { get => _health; private set => _health = value; }
    public int Speed { get => _speed; private set => _speed = value; }

    public void HealthSetUp(int value)
    {
        Health += value;
        Debug.Log($"Current {Health}");
    }

    public void SpeedSetUp(int value)
    { 
        Speed += value;
        Debug.Log($"Current {Speed}");
    }
}
