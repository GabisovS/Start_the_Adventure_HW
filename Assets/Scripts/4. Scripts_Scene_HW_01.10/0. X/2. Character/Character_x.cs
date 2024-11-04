using UnityEngine;

public class Character_x : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _rotationSpeed;

    public int Speed => _speed;
    public int RotationSpeed => _rotationSpeed;

}
