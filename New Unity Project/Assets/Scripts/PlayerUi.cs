using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
    public Collectable thisMythos;
    public Collectable teamMythos;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        teamMythos.characterFight = thisMythos.characterFight;
        teamMythos.charSprite = thisMythos.charSprite;
        teamMythos.power = thisMythos.power;
        teamMythos.defense = thisMythos.defense;
        teamMythos.hp = thisMythos.hp;
    }
}
