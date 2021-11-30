using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public Collectable thisMythos;
    public Collectable teamate;

    public int movement;

    private void OnMouseDown()
    {
        teamate.power = thisMythos.power;
        teamate.defense = thisMythos.defense;
    }

    private void OnMouseUp()
    {
        
    }
}
