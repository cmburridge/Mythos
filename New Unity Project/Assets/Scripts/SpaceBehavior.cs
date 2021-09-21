using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBehavior : MonoBehaviour
{
    private Vector3 spaceLocation;
    public GameObject openSpace;

    private void OnTriggerEnter2D(Collider2D other)
    {
        openSpace.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        openSpace.SetActive(false);
    }
}
