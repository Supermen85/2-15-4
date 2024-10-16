using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;

    private Coroutine _volumeChanger;

    public void TurnOn()
    {
        if (_alarmSound.isPlaying == false)
            _alarmSound.Play();
    }

    public void IncreaseVolume()
    {
        if (_volumeChanger != null)
            StopCoroutine(_volumeChanger);

        float maxVolume = 1f;
        _volumeChanger = StartCoroutine(ChangeVolume(maxVolume));
    }

    public void DecreaseVolume()
    {
        if (_volumeChanger != null)
            StopCoroutine(_volumeChanger);

        float minVolume = 0f;
        _volumeChanger = StartCoroutine(ChangeVolume(minVolume));
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_alarmSound.volume != target)
        {
            float speed = 0.2f;
            
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, target, speed * Time.deltaTime);

            yield return null;
        }

        if (_alarmSound.volume == 0)
            _alarmSound.Stop();
    }
}
