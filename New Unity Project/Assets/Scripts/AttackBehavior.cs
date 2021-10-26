using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    public Collectable target;
    public Collectable team;
    public Camera cam;
    public Vector3 location;

    public GameObject teamSpawn;
    public GameObject targetSpawn;

    public SpriteRenderer background;

    public void AttackSequence()
    {
        cam.transform.position = location;
        Instantiate(team.characterFight, teamSpawn.transform.position, Quaternion.identity, teamSpawn.transform);
        Instantiate(target.characterFight, targetSpawn.transform.position, Quaternion.identity, targetSpawn.transform);
    }
}
