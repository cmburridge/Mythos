using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class InstantiateBehavior : MonoBehaviour
{
    public Collectable collectableObj;
    public Collections collectionFull;
    public Collections collectionTeam;
    public int value;
    public int size;
    public GameObject obj1Position;
    public GameObject obj2Position;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        value = Random.Range(0, collectionFull.collection.Count);
        size = collectionFull.collection.Count;

        for (int i = value; i < size; i++)
        {
            collectableObj = collectionFull.collection[value];
            if (collectableObj.collected == false)
            {
                Instantiate(collectableObj.characterSelect, obj1Position.transform.position, Quaternion.identity, obj1Position.transform);
                collectableObj.onScreen = true;
            }
        }
    }

    public void Option1()
    {
        collectableObj.onScreen = false;
        collectableObj.collected = true;
        collectionTeam.collection.Add(collectableObj);
    }
    
}
