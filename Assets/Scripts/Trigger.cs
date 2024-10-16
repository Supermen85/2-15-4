using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public event Action ThiefEntered;
    public event Action ThiefExited;

    private void OnCollisionEnter(Collision collision)
    {
        if (IsThief(collision))
            ThiefEntered?.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (IsThief(collision))
            ThiefExited?.Invoke();
    }

    private bool IsThief(Collision collision)
    {
        return collision.gameObject.GetComponent<Thief>() != null; 
    }
}
