using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBehavior : MonoBehaviour
{
    private Vector3 spaceLocation;
    public GameObject openSpace;
    public Vector3Data position;

    private void Start()
    {
        position.value.x = 0;
        position.value.y = 0;
        position.value.z = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        openSpace.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        openSpace.SetActive(false);
    }
}
