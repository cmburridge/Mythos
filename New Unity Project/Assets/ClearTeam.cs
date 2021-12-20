using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTeam : MonoBehaviour
{
    public Collections team;
    
    void Start()
    {
        team.collection.Clear();
    }
    
}
