using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReset : MonoBehaviour
{
    public Collectable thisMythos;
    public Sprite defaultSprite;
    
    void Start()
    {
        thisMythos.charSprite = defaultSprite;
        thisMythos.hp = thisMythos.maxHp;
    }
}
