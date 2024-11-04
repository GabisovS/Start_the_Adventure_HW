using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class Enemy_x : MonoBehaviour // общая сущность для любого типа врага
{
    public const int Speed = 25;
    public const int RotationSpeed = 250;
    
    private IBehaviour_x _stateBehaviour;    // закрепляем возможность передвижения
    private IBehaviour_x _reactionBehaviour; // закрепляем возможность реакции
    private IBehaviour_x _currentBehaviour;  // поведение по умолчанию

    // при создании этого объекта нужно проинициализировать его 
    // каким-то поведением передвижения и реакции
    public void Init(IBehaviour_x stateBehaviour, IBehaviour_x reactionBehaviour)
    {
        _stateBehaviour = stateBehaviour;
        _reactionBehaviour = reactionBehaviour;

        _currentBehaviour = stateBehaviour;
    }

    private void Update()
    {
        _currentBehaviour.UpdateBehavior(); // вызываем выполнение движения
    }

    private void OnTriggerEnter(Collider other)
    {
        Character_x character = other.GetComponent<Character_x>();

        if (character != null)
        {
            _currentBehaviour = _reactionBehaviour;

            Debug.Log("Trigger enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _currentBehaviour = _stateBehaviour;

        gameObject.SetActive(true);

        Debug.Log("Trigger exit");
    }
}
