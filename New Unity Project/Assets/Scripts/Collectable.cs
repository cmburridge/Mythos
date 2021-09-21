using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Collectable : ScriptableObject
{
    public bool collected;
    public int costValue;
    public GameObject character;
}
