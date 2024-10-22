using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    [SerializeField] private Transform _coin;
    [SerializeField] private Vector3 _rotationAngle;

    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        transform.Rotate(_rotationAngle * _rotationSpeed * Time.deltaTime, Space.World);
    }
}
