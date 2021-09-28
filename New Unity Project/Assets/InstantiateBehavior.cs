using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBehavior : MonoBehaviour
{
    public Collectable mythos;
    public Collections mythosList;
    public int listValue;
    private void Start()
    {
        mythos = mythosList.collection[listValue];
        Instantiate(mythos.character);
    }
}
