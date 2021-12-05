using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class AiSimple : MonoBehaviour
{
    public Transform destination;
    private NavMeshAgent agentAI;
    private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();
    public GameObject moveCheck;
    public GameObject rangeCheck;
    public Vector3Data enLocation;
    public GameObject button;
    public UnityEvent attack;
    public UnityEvent nextEnemy;
    public AudioSource audioClip;
    public Collectable thisMythos;
    public float movement;
    public int randomNum;

    public float lockPos;

    private void OnEnable()
    {
        movement = thisMythos.speed;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
    }

    public void Decide()
    {
        randomNum = Random.Range(1,4);

        if (thisMythos.hp <= 0)
        { 
            StartCoroutine(NextTurn());
        }
        else if (randomNum == 1 || randomNum == 2)
        {
            AttackCheck();
        }
        else if (randomNum == 3 || randomNum == 4)
        {
            StartCoroutine(MoveAttack());
        }
    }

    private IEnumerator MoveAttack()
    {
        moveCheck.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        AttackCheck();
        movement = 0;
    }

    public void AttackCheck()
    {
        if (thisMythos.hp <= 0)
        { 
            StartCoroutine(NextTurn());
        }
        else
        {
            rangeCheck.SetActive(true);
        }
    }

    public void AttackSequence()
    {
        attack.Invoke();
        StartCoroutine(WaitTill());

    }

    private IEnumerator WaitTill()
    {
        yield return new WaitForSeconds(7);
        StartCoroutine(NextTurn());
    }

    public void GetLocations()
    {
        if (thisMythos.hp <= 0 || movement <= 0)
        {
            StartCoroutine(NextTurn());
        }
        else if (movement == 1)
        {
            StartCoroutine(move1());
        }
        else if (movement == 2)
        {
            StartCoroutine(move2());
        }
        else if (movement == 3)
        {
            StartCoroutine(move3());
        }
    }

    private IEnumerator move1()
    {
        yield return new WaitForSecondsRealtime(0);
        moveCheck.SetActive(true);
        movement = 0;
    }
    
    private IEnumerator move2()
    {
        moveCheck.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        moveCheck.SetActive(true);
        movement = 0;
    }
    
    private IEnumerator move3()
    {
        moveCheck.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        moveCheck.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        moveCheck.SetActive(true);
        movement = 0;
    }

    public void SetLocation()
    {
        if (movement <= 0)
        {
            destination.transform.position = enLocation.value;
            audioClip.Play();
            StartCoroutine(NextTurn());   
        }
        else
        {
            destination.transform.position = enLocation.value;
            audioClip.Play();
        }
    }

    public IEnumerator NextTurn()
    {
        yield return new WaitForSeconds(1);
        nextEnemy.Invoke();
        movement = thisMythos.speed;
    }

    private IEnumerator Start()
    {
        agentAI = GetComponent<NavMeshAgent>();
        while (true)
        {
            yield return waitObj;
            agentAI.destination = destination.position;
        }
    }

    public void Restart()
    {
        StartCoroutine(Start());
    }
}
