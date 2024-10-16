using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        _trigger.ThiefEntered += IncreaseAlarmVolume;
        _trigger.ThiefExited += DecreaseAlarmVolume;
    }

    private void OnDisable()
    {
        _trigger.ThiefEntered -= IncreaseAlarmVolume;
        _trigger.ThiefExited -= DecreaseAlarmVolume;
    }

    private void IncreaseAlarmVolume()
    {
        _alarm.TurnOn();
        _alarm.IncreaseVolume();
    }

    private void DecreaseAlarmVolume()
    {
        _alarm.DecreaseVolume();
    }
}
