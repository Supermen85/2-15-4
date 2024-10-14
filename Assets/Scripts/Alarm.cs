using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private bool _isThiefInside = false;

    private Coroutine _volumeChanger;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Thief>() == null) 
            return;

        _isThiefInside = true;

        if (_alarm.isPlaying == false)
            _alarm.Play();

        if (_volumeChanger != null)
            StopCoroutine(_volumeChanger);

        TurnOn();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Thief>() == null)
            return;

        _isThiefInside = false;

        if (_volumeChanger != null)
            StopCoroutine(_volumeChanger);

        TurnOn();
    }

    private void TurnOn()
    {
        float volume;

        if (_isThiefInside)
        {
            volume = 1f;
        }
        else
        {
            volume = 0f;
        }

        _volumeChanger = StartCoroutine(ChangeVolume(volume));
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_alarm.volume != target)
        {
            float speed = 0.2f;
            
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, target, speed * Time.deltaTime);

            yield return null;
        }

        if (_alarm.volume == 0)
            _alarm.Stop();
    }
}
