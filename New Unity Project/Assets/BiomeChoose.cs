using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BiomeChoose : MonoBehaviour
{
    public Collectable teamMythos;
    public Collectable targetMythos;
    public SpriteRenderer thisRen;
    public Image teamRen;
    public Image enemyRen;
    public Text teamNum;
    public Text enemyNum;
    public SpriteRenderer teamIcon;
    public SpriteRenderer enemyIcon;
    public Collectable target;
    public Collectable team;
    public int randomValue;
    public GameObject attackScene;
    public GameObject buttons;
    public Vector3 location;
    public Camera cam;
    public Text diceVal;

    public void ChangeBiome()
    {
        thisRen.sprite = teamMythos.biome;
        teamRen.sprite = teamMythos.attackIcon;
        enemyRen.sprite = targetMythos.attackIcon;
        teamNum.text = teamMythos.power.ToString();
        enemyNum.text = targetMythos.defense.ToString();
        teamIcon.sprite = teamMythos.charSprite;
        enemyIcon.sprite = targetMythos.charSprite;
    }
    
    public void Dice()
    {
        StartCoroutine(Roll());
    }

    public IEnumerator Roll()
    {
        yield return new WaitForSeconds(2);
        randomValue = Random.Range(1, 20);
        diceVal.text = randomValue.ToString();
        if (randomValue <= team.power)
        {
            Debug.Log("hit");
            StartCoroutine(Defend());
        }
        else
        {
            yield return new WaitForSeconds(2);
            Debug.Log("miss");
            attackScene.SetActive(false);
            cam.transform.position = location;
            buttons.SetActive(true);
        }
    }

    public IEnumerator Defend()
    {
        yield return new WaitForSeconds(2);
        randomValue = Random.Range(1, 20);
        diceVal.text = randomValue.ToString();
        if (randomValue <= target.defense)
        {
            yield return new WaitForSeconds(2);
            Debug.Log("block");
            attackScene.SetActive(false);
            cam.transform.position = location;
            buttons.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(2);
            Debug.Log("damaged");
            attackScene.SetActive(false);
            cam.transform.position = location;
            buttons.SetActive(true);
        }
    }
}



