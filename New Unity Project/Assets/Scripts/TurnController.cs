using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public Collectable teamMythos;
    public GameObject teamHold;

    public void TurnStart()
    {
        teamMythos.turnStart = true;
    }
}
