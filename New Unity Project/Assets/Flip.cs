using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public Collectable thisMythos;
    private void Awake()
    {
        if (thisMythos.collected == true)
        {
            transform.Rotate(0,180,0);
        }
    }
}
