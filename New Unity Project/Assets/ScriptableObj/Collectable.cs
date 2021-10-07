using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Collectable : ScriptableObject
{
    public bool collected;
    public GameObject character;
    public GameObject characterSelect;
    public string mythosName;
    public float hp;
    public float speed;
    public float power;
    public float defense;
}
