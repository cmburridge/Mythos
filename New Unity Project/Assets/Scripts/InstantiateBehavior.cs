using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiateBehavior : MonoBehaviour
{
    public Collectable mythos;
    public Collections mythosList;
    public int listValue;
    public Vector3 thisPosition;
    private void Start()
    {
        thisPosition.x = this.transform.position.x;
        thisPosition.y = this.transform.position.y;
        mythos = mythosList.collection[listValue];
        Instantiate(mythos.character,thisPosition,Quaternion.identity);
    }
}
