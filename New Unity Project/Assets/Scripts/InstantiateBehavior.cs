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
    public Collectable teamMythos;
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
    public new AudioSource audio;

    private void Start()
    {
        teamMythos.canAttack = false;
        Spawn();
    }

    private void Spawn()
    {
        if (collectionFull.collection.Count <= 1)
        {
            return;
        }
        else
        {
            value = Random.Range(0, collectionFull.collection.Count);
            size = collectionFull.collection.Count;

            for (var i = value; i < size; i++)
            {
                collectableObj1 = collectionFull.collection[value];
                Instantiate(collectableObj1.characterSelect, obj1Position.transform.position, Quaternion.identity,
                    obj1Position.transform);
                collectableObj1.onScreen = true;
            }

            collectableObj2 = collectableObj1;
            collectionFull.collection.Remove(collectableObj2);
            Spawn2();
        }
    }

    private void Spawn2()
    {
        value = Random.Range(0, collectionFull.collection.Count);
        {
            for (var i = value; i < size; i++)
            {
                if (collectionFull.collection[value].onScreen == false)
                {
                    collectableObj1 = collectionFull.collection[value];
                    Instantiate(collectableObj1.characterSelect, obj2Position.transform.position, Quaternion.identity, obj2Position.transform);
                }
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
    
    public void NoneSelected()
    {
        StartCoroutine(Option3());
    }

    public IEnumerator Option1()
    {
        Instantiate(transition, background.transform.position, Quaternion.identity);
        collectionTeam.collection.Add(collectableObj2);
        collectionFull.collection.Remove(collectableObj2);
        collectionFull.collection.Remove(collectableObj1);
        collectableObj2.onScreen = false;
        collectableObj2.collected = true;
        yield return new WaitForSecondsRealtime(1);
        background.SetActive(false);
        audio.Play();
    }
    
    public IEnumerator Option2()
    {
        Instantiate(transition, background.transform.position, Quaternion.identity);
        collectionTeam.collection.Add(collectableObj1);
        collectionFull.collection.Remove(collectableObj1);
        collectableObj2.onScreen = false;
        collectableObj1.collected = true;
        yield return new WaitForSecondsRealtime(1);
        background.SetActive(false);
        audio.Play();
    }

    public IEnumerator Option3()
    {
        Instantiate(transition, background.transform.position, Quaternion.identity);
        collectableObj2.onScreen = false;
        yield return new WaitForSecondsRealtime(1);
        background.SetActive(false);
        audio.Play();
    }
}
