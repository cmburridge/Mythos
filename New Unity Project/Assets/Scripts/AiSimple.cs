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

    public float lockPos;

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
    }

    public void GetLocations()
    {
        if (thisMythos.hp <= 0)
        {
            StartCoroutine(NextTurn());
        }
        else
        {
            moveCheck.SetActive(true);   
        }
    }

    public void SetLocation()
    {
        destination.transform.position = enLocation.value;
        audioClip.Play();
        StartCoroutine(NextTurn());
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
