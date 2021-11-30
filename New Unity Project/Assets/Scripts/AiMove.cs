using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AiMove : MonoBehaviour
{
    public GameObject thisMythos;
    public Vector3 location;
    public Vector3Data enLocation;
    public UnityEvent moveTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        location = other.transform.position;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        yield return new WaitForSecondsRealtime(1);
        enLocation.value = location;
        moveTriggered.Invoke();
        StartCoroutine(TurnOff());
    }

    public IEnumerator TurnOff()
    {
        yield return new WaitForSecondsRealtime(0);
        this.gameObject.SetActive(false);
    }
}
