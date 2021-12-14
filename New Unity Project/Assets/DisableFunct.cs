using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFunct : MonoBehaviour
{
    public GameObject obj;
    private void OnDisable()
    {
       obj.SetActive(false);
    }
}
