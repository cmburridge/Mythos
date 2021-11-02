using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCheck : MonoBehaviour
{
   public Collectable thisMythos;
   public Sprite hurt1, hurt2, hurt3, dead;
   public GameObject prefab;
   
   private void OnEnable()
   {
      StartCoroutine(Check());
   }

   public IEnumerator Check()
   {
      yield return new WaitForSeconds(1);
      if (thisMythos.hp == 3)
      {
         thisMythos.charSprite = hurt1;
      }
      else
      if (thisMythos.hp == 2)
      {
         thisMythos.charSprite = hurt2;
      }
      else
      if (thisMythos.hp == 1)
      {
         thisMythos.charSprite = hurt3;
      }
      else
      if (thisMythos.hp <= 0)
      {
         thisMythos.charSprite = dead;
         Instantiate(prefab, this.transform.position, Quaternion.identity);
         yield return new WaitForSeconds(1);
         Destroy(this.gameObject);
      }
   }
}
