using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BiomeChoose : MonoBehaviour
{
    public Collectable teamMythos;
    public Collectable targetMythos;
    public Collectable target;
    public Collectable team;
    
    public SpriteRenderer thisRen;
    public SpriteRenderer otherRen;
    public SpriteRenderer teamIcon;
    public SpriteRenderer enemyIcon;
    
    public int randomValue;
    
    public Vector3 location;

    public UnityEvent onDisable;
    
    public Text teamNum;
    public Text enemyNum;
    public Text diceVal;
    
    public new AudioSource audio;
    public AudioClip miss;
    
    public GameObject attackScene;
    public GameObject buttons;
    public GameObject targetSpawn;
    public GameObject defend;
    public GameObject missed;
    public GameObject missLocation;
    public GameObject transition;
    public GameObject targetEffects;
    public GameObject teamEffects;
    public GameObject teamGroup;
    public GameObject enemyGroup;
    public GameObject button;
    public GameObject diceText;
    public GameObject teamHold;

    public void OnEnable()
    {
        diceText.SetActive(true);
        teamNum.text = teamMythos.power.ToString();
        enemyNum.text = targetMythos.defense.ToString();
        diceVal.text = " ";
        thisRen.sprite = teamMythos.biome;
        otherRen.sprite = targetMythos.biome;
        teamIcon.sprite = teamMythos.charSprite;
        enemyIcon.sprite = targetMythos.charSprite;
    }

    private void OnDisable()
    {
        teamHold.SetActive(true);
        onDisable.Invoke();
    }

    public void ButtonPress()
    {
        StartCoroutine(Roll());
        diceText.SetActive(false);
    }

    public IEnumerator Roll()
    {
        randomValue = Random.Range(1, 21);
        audio.Play();
        diceVal.text = randomValue.ToString();
        if (randomValue <= team.power)
        {
            Debug.Log("hit");
            StartCoroutine(AiDefend());
        }
        else if (randomValue >= team.power)
        {
            yield return new WaitForSecondsRealtime(1);
            audio.PlayOneShot(miss, 1);
            Instantiate(missed, missLocation.transform.position, Quaternion.identity, targetEffects.transform );
            yield return new WaitForSecondsRealtime(2);
            Debug.Log("miss");
            Instantiate(transition, attackScene.transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(1);
            buttons.SetActive(true);
            teamGroup.SetActive(true);
            enemyGroup.SetActive(true);
            button.SetActive(true);
            attackScene.SetActive(false);
            yield break;
        }
    }

    public IEnumerator AiDefend()
    {
        yield return new WaitForSecondsRealtime(2);
        randomValue = Random.Range(1, 21);
        audio.Play();
        diceVal.text = randomValue.ToString();
        if (randomValue <= target.defense)
        {
            yield return new WaitForSecondsRealtime(1);
            Instantiate(defend, targetEffects.transform.position, Quaternion.identity, targetEffects.transform );
            yield return new WaitForSecondsRealtime(1);
            Debug.Log("block");
            Instantiate(transition, attackScene.transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(1);
            buttons.SetActive(true);
            teamGroup.SetActive(true);
            enemyGroup.SetActive(true);
            button.SetActive(true);
            attackScene.SetActive(false);
            yield break;
        }
        else if (randomValue >= target.defense)
        {
            yield return new WaitForSecondsRealtime(1);
            Instantiate(team.special, targetEffects.transform.position, Quaternion.identity, targetEffects.transform);
            yield return new WaitForSecondsRealtime(1);
            Debug.Log("damaged");
            Instantiate(transition, attackScene.transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(1);
            buttons.SetActive(true);
            teamGroup.SetActive(true);
            enemyGroup.SetActive(true);
            button.SetActive(true);
            attackScene.SetActive(false);
            yield break;
        }
    }

    public void StartAttack()
    {
        StartCoroutine(AiRoll());
        teamNum.text = teamMythos.defense.ToString();
        enemyNum.text = targetMythos.power.ToString();
    }

    public IEnumerator AiRoll()
    {
        yield return new WaitForSecondsRealtime(1);
        randomValue = Random.Range(1, 21);
        audio.Play();
        diceVal.text = randomValue.ToString();
        if (randomValue <= target.power)
        {
            Debug.Log("hit");
            StartCoroutine(Defend());
        }
        else if (randomValue >= target.power)
        {
            yield return new WaitForSecondsRealtime(1);
            audio.PlayOneShot(miss, 1);
            Instantiate(missed, missLocation.transform.position, Quaternion.identity, targetEffects.transform );
            yield return new WaitForSecondsRealtime(2);
            Debug.Log("miss");
            Instantiate(transition, attackScene.transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(1);
            buttons.SetActive(true);
            teamGroup.SetActive(true);
            enemyGroup.SetActive(true);
            button.SetActive(true);
            attackScene.SetActive(false);
            yield break;
        }
    }
    
    public IEnumerator Defend()
    {
        yield return new WaitForSecondsRealtime(2);
        randomValue = Random.Range(1, 21);
        audio.Play();
        diceVal.text = randomValue.ToString();
        if (randomValue <= team.defense)
        {
            yield return new WaitForSecondsRealtime(1);
            Instantiate(defend, teamEffects.transform.position, Quaternion.identity, targetEffects.transform );
            yield return new WaitForSecondsRealtime(1);
            Debug.Log("block");
            Instantiate(transition, attackScene.transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(1);
            buttons.SetActive(true);
            teamGroup.SetActive(true);
            enemyGroup.SetActive(true);
            button.SetActive(true);
            attackScene.SetActive(false);
            yield break;
        }
        else if (randomValue >= team.defense)
        {
            yield return new WaitForSecondsRealtime(1);
            Instantiate(target.special, teamEffects.transform.position, Quaternion.identity, targetEffects.transform);
            yield return new WaitForSecondsRealtime(1);
            Debug.Log("damaged");
            Instantiate(transition, attackScene.transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(1);
            buttons.SetActive(true);
            teamGroup.SetActive(true);
            enemyGroup.SetActive(true);
            button.SetActive(true);
            attackScene.SetActive(false);
            yield break;
        }
    }
}



