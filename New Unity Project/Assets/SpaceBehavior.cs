using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBehavior : MonoBehaviour
{
    private Vector3 spaceLocation;
    private bool empty = true;
    public GameObject artObj;
    public SpriteRenderer objSprite;
    

    public void Update()
    {
        if (empty == false)
        {
            objSprite.color = Color.red;
        }
        else
        {
            objSprite.color = Color.green;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        artObj.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        artObj.SetActive(false);
    }
}
