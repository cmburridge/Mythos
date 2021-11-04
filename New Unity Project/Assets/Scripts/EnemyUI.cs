using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyUI : MonoBehaviour
{
    public Sprite icon;
    public Sprite menu;
    public SpriteRenderer enemyIcon;
    public SpriteRenderer enemyMenu;
    public GameObject target;
    public Collectable thisMythos;
    public Collectable targetMythos;

    public void OnEnable()
    {
        targetMythos.characterFight = null;
        targetMythos.power = 0;
        targetMythos.defense = 0;
        targetMythos.hp = 0;
        target.SetActive(false);
        enemyIcon.sprite = null;
        enemyMenu.sprite = null;
        targetMythos.charSprite = null;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        targetMythos.characterFight = null;
        targetMythos.charSprite = null;
        targetMythos.power = 0;
        targetMythos.defense = 0;
        targetMythos.hp = 0;
        target.SetActive(false);
        enemyIcon.sprite = null ;
        enemyMenu.sprite = null ;
    }
}
