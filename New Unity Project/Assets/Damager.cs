using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public Collectable thisMythos;
    
    private void OnTriggerExit2D(Collider2D other)
    {
        thisMythos.hp += -1;
    }
}
