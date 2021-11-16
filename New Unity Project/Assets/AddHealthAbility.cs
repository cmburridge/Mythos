using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using Random = UnityEngine.Random;

public class AddHealthAbility : MonoBehaviour
{
    public Collectable thisMythos;
    
    public int _randomValue;

    private void Awake()
    {
        if (thisMythos.hp < thisMythos.maxHp)
        {
            _randomValue = Random.Range(1, 2);
            if (_randomValue > 2)
            {
                Debug.Log("Less");
                thisMythos.hp += 1;
            }
            else
            {
                Debug.Log("More");
            }
        }
        else
        {
            Debug.Log("NotHurt");
        }
    }
}
