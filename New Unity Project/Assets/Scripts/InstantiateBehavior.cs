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
    public Collections collectionFull;
    public Collections collectionTeam;
    public int listValue;
    public int value1;
    public int value2;
    public Vector3 thisPosition;
    private void Start()
    {
        value1 = Random.Range(0, collectionFull.collection.Count);
        thisPosition.x = this.transform.position.x;
        thisPosition.y = this.transform.position.y;
        collectableObj = collectionFull.collection[value1];
        Spawn();
    }

    public void Spawn()
    {
        Instantiate(collectableObj.characterSelect,thisPosition,Quaternion.identity);
    }

    public void Add()
    {
        Debug.Log("Works");
        //collectionTeam.collection.Add(collectableObj);
    }
}
