using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public Collectable teamMythos;

    public void TurnStart()
    {
        teamMythos.turnStart = true;
    }
}
