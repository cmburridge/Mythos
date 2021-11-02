using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCheck : MonoBehaviour
{
    public Collectable thisMythos;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        thisMythos.canAttack = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        thisMythos.canAttack = false;
    }
}
