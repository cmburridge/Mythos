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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        targetMythos.characterFight = thisMythos.characterFight;
        targetMythos.charSprite = thisMythos.charSprite;
        targetMythos.power = thisMythos.power;
        targetMythos.defense = thisMythos.defense;
        targetMythos.hp = thisMythos.hp;
        target.SetActive(true);
        enemyIcon.sprite = icon ;
        enemyMenu.sprite = menu ;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        target.SetActive(false);
    }
}
