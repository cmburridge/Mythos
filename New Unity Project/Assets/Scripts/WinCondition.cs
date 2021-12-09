using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public float amount;
    public FloatData teamAmount;
    public FloatData enemyAmount;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject unlockScreen;
    public GameObject music;
    public GameObject button;
    public Collectable thisMythos;

    private void Start()
    {
        teamAmount.value = 0;
        enemyAmount.value = 0;
    }

    void Update()
    {
        if (enemyAmount.value >= amount && thisMythos.collected == false)
        {
            unlockScreen.SetActive(true); 
            button.SetActive(false);
            music.SetActive(false);
        }
        if (enemyAmount.value >= amount && thisMythos.collected == true)
        {
           winScreen.SetActive(true); 
           button.SetActive(false);
           music.SetActive(false);
        }
        else if (teamAmount.value >= amount)
        {
            loseScreen.SetActive(true); 
            button.SetActive(false);
            music.SetActive(false);
        }
    }
}
