using TMPro;
using UnityEngine;

public class DistanceDetector : MonoBehaviour
{
    [SerializeField] private TMP_Text _distanceText;

    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    [SerializeField] private float _minDistance;

    public float Distance { get; private set; }

    void Update()
    {
        Vector3 direction = _secondPoint.position - _firstPoint.position;
        Distance = direction.magnitude;

        DistanceToText(Distance);
        DistanceToDetect(Distance);
    }

    private void DistanceToText(float distance)
    {
        _distanceText.text = distance.ToString("0.00");
    }

    private void DistanceToDetect(float distance)
    {
        if (distance <= _minDistance)
        {
            _distanceText.color = Color.green;
        }
        else
        {
            _distanceText.color = Color.red;
        }
    }
}
