using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedAbility : MonoBehaviour
{
    public Collectable thisMythos;
    public Sprite biomeBuff;
    private void OnEnable()
    {
        if (thisMythos.biome == biomeBuff)
        {
            thisMythos.speed += 2;
        }
    }
}
