using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Collectable : ScriptableObject
{
    public bool onScreen;
    public bool collected;
    public GameObject character;
    public GameObject characterSelect;
    public GameObject characterDetails;
    public GameObject characterFight;
    public Sprite charSprite;
    public Sprite charMenu;
    public Sprite biome;
    public string mythosName;
    public float hp;
    public float speed;
    public float power;
    public float defense;
}
