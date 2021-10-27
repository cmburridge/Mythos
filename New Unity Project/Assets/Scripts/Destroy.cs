using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float time = 5;
    
    private void Start()
    {
        StartCoroutine(DestroyThis());
    }

    private IEnumerator DestroyThis()
    {
        yield return new WaitForSecondsRealtime(time);
        Debug.Log("destroyed");
        Destroy(this.gameObject);
    }
}
