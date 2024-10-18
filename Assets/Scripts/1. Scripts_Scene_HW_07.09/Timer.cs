using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;

    [SerializeField] private float _startTime;
    
    private float _zeroTime;

    public float CurrentTime { get; private set; }

    private void Start()
    {
        CurrentTime = _startTime;
    }

    public void SwitchOn()
    {
        CurrentTime -= Time.deltaTime;

        if (CurrentTime <= _zeroTime)
        {
            CurrentTime = _zeroTime;
        }

        _timerText.text = CurrentTime.ToString("00.00");
    }

    public void ResetTimer()
    {
        CurrentTime = _startTime;
    }


}
