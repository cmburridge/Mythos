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
    public Vector3 location;
    public int listValue;

    public void Spawn()
    {
        collectableObj = collectionTeam.collection[listValue];
        Instantiate(collectableObj.character, this.transform.position, Quaternion.identity);
    }

    public void Icons()
    {
        menu.sprite = collectableObj.charMenu;
        Instantiate(collectableObj.characterDetails, location, Quaternion.identity, menu.gameObject.transform);
        icon.sprite = collectableObj.charSprite;
    }
}
