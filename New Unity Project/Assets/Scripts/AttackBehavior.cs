using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackBehavior : MonoBehaviour
{
    public Collectable target;
    public Collectable team;
    public Camera cam;
    public Vector3 location;
    public int randomValue;
    public GameObject teamSpawn;
    public GameObject targetSpawn;
    public SpriteRenderer background;

    private void Start()
    {
        target.power = 0;
        target.defense = 0;
        team.power = 0;
        team.defense = 0;
    }

    public void AttackSequence()
    {
        background.sprite = team.biome;
        cam.transform.position = location;
        Instantiate(team.characterFight, teamSpawn.transform.position, Quaternion.identity, teamSpawn.transform);
        Instantiate(target.characterFight, targetSpawn.transform.position, Quaternion.identity, targetSpawn.transform);
    }

    public void Roll()
    {
        randomValue = Random.Range(1, 20);
        if (team.power >= randomValue)
        {
            Defend();
        }
        else
        {
            Debug.Log("miss");
        }
    }

    public void Defend()
    {
        randomValue = Random.Range(1, 20);
        if (target.defense >= randomValue)
        {
            Debug.Log("block");
        }
        else
        {
            Debug.Log("hit");
        }
    }
}
