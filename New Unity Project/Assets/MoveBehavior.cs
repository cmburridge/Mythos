using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : MonoBehaviour
{
    public Vector3Data position;
    public Vector3Data originalPosition;
    private void OnTriggerEnter2D(Collider2D other)
    {
        position.value = other.transform.position;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //position.value = originalPosition.value;
    }
}
