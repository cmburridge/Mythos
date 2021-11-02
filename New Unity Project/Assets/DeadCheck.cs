using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCheck : MonoBehaviour
{
   public Collectable thisMythos;
   
   private void OnEnable()
   {
      if (thisMythos.hp <= 0)
      {
         Destroy(this.gameObject);
      }
   }
}
