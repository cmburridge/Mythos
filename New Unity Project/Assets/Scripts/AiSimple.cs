using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AiSimple : MonoBehaviour
{
    public Transform destination;
    private NavMeshAgent agentAI;
    private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();
    public GameObject moveCheck;
    public Vector3Data enLocation;
    public GameObject button;
    public UnityEvent nextEnemy;
    public AudioSource audioClip;
    public Collectable thisMythos;
    public float movement;

    public float lockPos;

    private void OnEnable()
    {
        movement = thisMythos.speed;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
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
        Debug.Log("yes");
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
