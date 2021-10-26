using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
