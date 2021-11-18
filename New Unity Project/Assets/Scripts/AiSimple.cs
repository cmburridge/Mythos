using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AiSimple : MonoBehaviour
{
    public Transform destination;
    private NavMeshAgent agent;
    private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();
    public GameObject moveCheck;
    public Vector3Data enLocation;
    public GameObject button;
    public UnityEvent nextEnemy;

    public float lockPos;

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
    }

    public void GetLocations()
    {
        moveCheck.SetActive(true);
    }

    public void SetLocation()
    {
        destination.transform.position = enLocation.value;
        nextEnemy.Invoke();
    }

    private IEnumerator Start()
    {
        agent = GetComponent<NavMeshAgent>();
        while (true)
        {
            yield return waitObj;
            agent.destination = destination.position;
        }
    }

    public void Restart()
    {
        StartCoroutine(Start());
    }
}
