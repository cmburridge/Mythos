using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPrep : MonoBehaviour
{
    public Collectable thisMythos;
    public GameObject button;

    public void Update()
    {
        if (thisMythos.canAttack != true)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
        }
    }
}
