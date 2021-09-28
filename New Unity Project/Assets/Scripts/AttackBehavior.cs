using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : MonoBehaviour
{
    public Collectable target;
    public Collectable team;
    int[] randomArray = new int[20];

    public void Roll()
    {
        
        Debug.Log(target.power);

        //for(int arrayIndex = 0; arrayIndex < randomArray.Length; arrayIndex++)
        //{
            //randomArray[arrayIndex] = Random.Range(0, 20);
       // }
        
        //if (target.power >= randomArray[0])
        //{
            //Debug.Log("hit");
       // }
        //else
       // {
            //Debug.Log("miss");
        //}
    }
}
