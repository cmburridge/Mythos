using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Text diceVal;
    public GameObject targetSpawn;
    public GameObject defend;
    public GameObject transition;
    public GameObject defendHolder;
    public new AudioSource audio;

    public void OnEnable()
    {
        diceVal.text = "0";
        thisRen.sprite = teamMythos.biome;
        teamRen.sprite = teamMythos.attackIcon;
        enemyRen.sprite = targetMythos.attackIcon;
        teamNum.text = teamMythos.power.ToString();
        enemyNum.text = targetMythos.defense.ToString();
        teamIcon.sprite = teamMythos.charSprite;
        enemyIcon.sprite = targetMythos.charSprite;
        StartCoroutine(Roll());
    }

    public IEnumerator Roll()
    {
        yield return new WaitForSecondsRealtime(3);
        randomValue = Random.Range(1, 20);
        audio.Play();
        diceVal.text = randomValue.ToString();
        if (randomValue <= team.power)
        {
            Debug.Log("hit");
            StartCoroutine(Defend());
        }
        else
        {
            yield return new WaitForSecondsRealtime(4);
            Debug.Log("miss");
            Instantiate(transition, attackScene.transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(1);
            attackScene.SetActive(false);
            buttons.SetActive(true);
        }
    }

    public IEnumerator Defend()
    {
        yield return new WaitForSeconds(2);
        randomValue = Random.Range(1, 20);
        audio.Play();
        diceVal.text = randomValue.ToString();
        if (randomValue <= target.defense)
        {
            Instantiate(defend, defendHolder.transform.position, Quaternion.identity, defendHolder.transform );
            yield return new WaitForSecondsRealtime(2);
            Debug.Log("block");
            Instantiate(transition, attackScene.transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(1);
            attackScene.SetActive(false);
            buttons.SetActive(true);
        }
        else
        {
            Instantiate(team.special, defendHolder.transform.position, Quaternion.identity, targetSpawn.transform);
            yield return new WaitForSecondsRealtime(2);
            Debug.Log("damaged");
            Instantiate(transition, attackScene.transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(1);
            attackScene.SetActive(false);
            buttons.SetActive(true);
        }
    }
}



