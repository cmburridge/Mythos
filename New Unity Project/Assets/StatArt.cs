using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatArt : MonoBehaviour
{
    public Collectable thisMythos;
    public Vector3 location;
    

    private void OnEnable()
    { 
        Instantiate(thisMythos.characterDetails, location, Quaternion.identity, this.gameObject.transform);
    }

    private void OnDisable()
    {
        foreach (Transform t in this.transform)
        {
            Destroy(t.gameObject);
        }
    }
}
