using System;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehaviour : MonoBehaviour
{
    public UnityEvent startEvent, applicationQuitEvent;

    private void Start()
    {
        startEvent.Invoke();
    }

    private void OnApplicationQuit()
    {
        applicationQuitEvent.Invoke();
    }
}
