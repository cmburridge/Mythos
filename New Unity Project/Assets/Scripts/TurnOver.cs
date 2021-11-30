using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOver : MonoBehaviour
{
    public Collectable thisMythos;
    public Collectable teamMythos;
    private void Awake()
    {
        thisMythos.turnOver = true;
        teamMythos.canAttack = false;
        thisMythos.canMove = false;
    }
}
