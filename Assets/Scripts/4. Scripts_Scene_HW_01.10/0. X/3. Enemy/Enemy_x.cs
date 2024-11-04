using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class Enemy_x : MonoBehaviour // ����� �������� ��� ������ ���� �����
{
    public const int Speed = 25;
    public const int RotationSpeed = 250;
    
    private IBehaviour_x _stateBehaviour;    // ���������� ����������� ������������
    private IBehaviour_x _reactionBehaviour; // ���������� ����������� �������
    private IBehaviour_x _currentBehaviour;  // ��������� �� ���������

    // ��� �������� ����� ������� ����� ������������������� ��� 
    // �����-�� ���������� ������������ � �������
    public void Init(IBehaviour_x stateBehaviour, IBehaviour_x reactionBehaviour)
    {
        _stateBehaviour = stateBehaviour;
        _reactionBehaviour = reactionBehaviour;

        _currentBehaviour = stateBehaviour;
    }

    private void Update()
    {
        _currentBehaviour.UpdateBehavior(); // �������� ���������� ��������
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
