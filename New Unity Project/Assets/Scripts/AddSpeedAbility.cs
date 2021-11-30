using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedAbility : MonoBehaviour
{
    public Collectable thisMythos;
    public Sprite biomeBuff;
    public float ogSpd = 2;

    private void Start()
    {
        thisMythos.speed = ogSpd;
    }

    public void OnEnable()
    {
        if (thisMythos.biome == biomeBuff)
        {
            thisMythos.speed += 2;
        }
    }
}
