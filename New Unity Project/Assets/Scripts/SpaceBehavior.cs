using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBehavior : MonoBehaviour
{
    private Vector3 spaceLocation;
    public GameObject artObj;
    public SpriteRenderer objSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        artObj.SetActive(true);
        objSprite.color = Color.black;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        artObj.SetActive(false);
    }
}
