using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnController : MonoBehaviour
{
    public Collectable teamMythos;
    public GameObject teamHold;
    public UnityEvent reset;

    public void TurnStart()
    {
        reset.Invoke();
        teamMythos.turnStart = true;
    }
}
