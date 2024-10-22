using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer_2 : MonoBehaviour
{
    [SerializeField] private TMP_Text _time;
    [SerializeField] private float _startTime;

    private float _zeroTime = 0f;
    public float CurrentTime { get; private set; }

    public void SwitchOn()
    { 
        CurrentTime -= Time.deltaTime;

        if (CurrentTime <= _zeroTime)
        {
            CurrentTime = _zeroTime;
        }

        _time.text = CurrentTime.ToString("00.00");
    }

    public void SetTime()
    { 
        CurrentTime = _startTime;
    }
}
