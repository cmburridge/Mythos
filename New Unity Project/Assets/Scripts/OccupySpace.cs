using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupySpace : MonoBehaviour
{
    public GameObject space;

    private void OnTriggerEnter2D(Collider2D other)
    {
        space.SetActive(false);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        space.SetActive(true);
    }
}
