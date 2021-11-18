using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AiSimple : MonoBehaviour
{
    public Transform destination;
    private NavMeshAgent agent;
    private WaitForFixedUpdate waitObj = new WaitForFixedUpdate();

    public float lockPos;

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
    }
    
    private IEnumerator Start ()
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
