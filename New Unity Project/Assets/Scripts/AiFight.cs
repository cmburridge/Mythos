using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AiFight : MonoBehaviour
{
    public Collectable thisMythos;
    public Collectable targetMythos;
    public UnityEvent attackTriggered;
    public UnityEvent notTriggered;
    public bool canAttack = false;

    private void OnEnable()
    {
        canAttack = false;
        StartCoroutine(TurnOff());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canAttack = true;
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        targetMythos.characterFight = thisMythos.characterFight;
        targetMythos.charSprite = thisMythos.charSprite;
        targetMythos.power = thisMythos.power;
        targetMythos.defense = thisMythos.defense;
        targetMythos.hp = thisMythos.hp;
        targetMythos.special = thisMythos.special;
        yield return new WaitForSecondsRealtime(1);
        attackTriggered.Invoke();
        StartCoroutine(TurnOff());
    }

    public IEnumerator TurnOff()
    {
        yield return new WaitForSecondsRealtime(2);
        if (canAttack == false)
        {
            notTriggered.Invoke();
            this.gameObject.SetActive(false);
        }
        else
        {
            yield return new WaitForSecondsRealtime(0);
            canAttack = false;
            this.gameObject.SetActive(false);
        }
    }
}
