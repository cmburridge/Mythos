using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    public Collectable target;
    public Collectable team;
    public int randomValue;
    
    public void Roll()
    {
        randomValue = Random.Range(1, 20);
        if (team.power >= randomValue)
        {
            Debug.Log("hit");
        }
        else
        {
            Debug.Log("miss");
        }
    }
}
