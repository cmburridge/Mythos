using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class InstantiateBehavior : MonoBehaviour
{
    public Collectable collectableObj;
    public Collectable collectableObj2;
    public Collections collectionFull;
    public Collections collectionTeam;
    public int listValue;
    public int value1;
    public int value2;
    public GameObject obj1Position;
    public GameObject obj2Position;
    
    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        value1 = Random.Range(0, collectionFull.collection.Count);
        collectableObj = collectionFull.collection[value1];
        if (collectionTeam.collection.Contains(collectableObj))
        {
            Spawn();
        }
        else
        {
            Instantiate(collectableObj.characterSelect, obj1Position.transform.position, Quaternion.identity, obj1Position.transform);
            collectableObj2 = collectableObj;
            Spawn2();
        }
    }

    public void Spawn2()
    {
        value2 = Random.Range(0, collectionFull.collection.Count);
        if (value2 != value1)
        {
            collectableObj = collectionFull.collection[value2];
            if (collectionTeam.collection.Contains(collectableObj))
            {
                Spawn2();
            }
            else
            {
                Instantiate(collectableObj.characterSelect, obj2Position.transform.position, Quaternion.identity,obj2Position.transform);   
            }
        }
        else
        {
            Spawn2();
        }
    }

    public void Add()
    {
        collectionTeam.collection.Add(collectableObj2);
    }
    
    public void Add2()
    {
        collectionTeam.collection.Add(collectableObj);
    }
}
