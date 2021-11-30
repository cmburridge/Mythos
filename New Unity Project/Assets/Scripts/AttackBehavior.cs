using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AttackBehavior : MonoBehaviour
{
    public Collectable target;
    public Collectable team;
    public Camera cam;
    public Vector3 location;

    public GameObject teamSpawn;
    public GameObject targetSpawn;

    public GameObject background;
    public GameObject Aibackground;
    public GameObject transition;
    public GameObject button;

    public UnityEvent activate;
    

    public void StartAttack()
    {
        StartCoroutine(AttackSequence());
    }

    public void AiAttack()
    {
        StartCoroutine(AiAttackSequence());
    }

    private IEnumerator AttackSequence()
    {
        button.SetActive(false);
        Instantiate(transition, background.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        background.SetActive(true);
        yield return new WaitForSeconds(0);
        Instantiate(team.characterFight, teamSpawn.transform.position, Quaternion.identity, teamSpawn.transform);
        Instantiate(target.characterFight, targetSpawn.transform.position, Quaternion.identity, targetSpawn.transform);
    }
    
    private IEnumerator AiAttackSequence()
    {
        button.SetActive(false);
        Instantiate(transition, background.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Aibackground.SetActive(true);
        yield return new WaitForSeconds(0);
        Instantiate(team.characterFight, teamSpawn.transform.position, Quaternion.identity, teamSpawn.transform);
        Instantiate(target.characterFight, targetSpawn.transform.position, Quaternion.identity, targetSpawn.transform);
        activate.Invoke();
    }
}
