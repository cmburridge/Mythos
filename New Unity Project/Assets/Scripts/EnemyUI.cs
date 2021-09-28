using System;
using System.Collections;
using System.Collections.Generic;
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

    

    private void OnMouseDown()
    {
        target.SetActive(true);
        enemyIcon.sprite = icon ;
        enemyMenu.sprite = menu ;
    }
}
