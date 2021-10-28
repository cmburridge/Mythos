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
    public Collectable collectableObj1;
    public Collectable collectableObj2;
    public Collections collectionFull;
    public Collections collectionTeam;
    public int value;
    public int size;
    public GameObject obj1Position;
    public GameObject obj2Position;
    public GameObject transition;
    public GameObject background;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        value = Random.Range(0, collectionFull.collection.Count);
        size = collectionFull.collection.Count;

        for (var i = value; i < size; i++)
        {
            collectableObj1 = collectionFull.collection[value];
            if (collectableObj1.collected == false)
            {
                Instantiate(collectableObj1.characterSelect, obj1Position.transform.position, Quaternion.identity, obj1Position.transform);
                collectableObj1.onScreen = true;
            }
        }
        collectableObj2 = collectableObj1;
        Spawn2();
    }

    private void Spawn2()
    {
        value = Random.Range(0, collectionFull.collection.Count);
        size = collectionFull.collection.Count;

        for (var i = value; i < size; i++)
        {
            collectableObj1 = collectionFull.collection[value];
            if (collectableObj1.collected == false & collectableObj1.onScreen == false)
            {
                Instantiate(collectableObj1.characterSelect, obj2Position.transform.position, Quaternion.identity, obj2Position.transform);
            }
        }
    }

    public void SelectedFirst()
    {
        StartCoroutine(Option1());
    }
    
    public void SelectedSecond()
    {
        StartCoroutine(Option2());
    }

    public IEnumerator Option1()
    {
        Instantiate(transition, background.transform.position, Quaternion.identity);
        collectionTeam.collection.Add(collectableObj2);
        collectableObj2.onScreen = false;
        collectableObj2.collected = true;
        yield return new WaitForSecondsRealtime(1);
        background.SetActive(false);
    }
    
    public IEnumerator Option2()
    {
        Instantiate(transition, background.transform.position, Quaternion.identity);
        collectionTeam.collection.Add(collectableObj1);
        collectableObj2.onScreen = false;
        collectableObj1.collected = true;
        yield return new WaitForSecondsRealtime(1);
        background.SetActive(false);
    }
}
