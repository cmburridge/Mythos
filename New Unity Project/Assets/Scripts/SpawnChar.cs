using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnChar : MonoBehaviour
{
    public Collectable collectableObj;
    public Collections collectionTeam;
    public SpriteRenderer menu;
    public SpriteRenderer icon;
    public int listValue;

    public void Spawn()
    {
        collectableObj = collectionTeam.collection[listValue];
        Instantiate(collectableObj.character, this.transform.position, Quaternion.identity);
    }

    public void Icons()
    {
        menu.sprite = collectableObj.charMenu;
        icon.sprite = collectableObj.charSprite;
    }
}
