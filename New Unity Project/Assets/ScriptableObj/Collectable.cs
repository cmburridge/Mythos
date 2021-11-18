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
    public bool canAttack = false;
    public bool turnOver = false;
    public bool turnStart = false;
    public Sprite charSprite;
    public Sprite charMenu;
    public Sprite biome;
    public Sprite attackIcon;
    public string mythosName;
    public float hp;
    public float maxHp;
    public float speed;
    public float power;
    public float defense;
    public GameObject special;
}
