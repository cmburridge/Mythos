using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeType : MonoBehaviour
{
    public Collectable thisMythos;
    public Sprite desert, mountain, woodlands, darklands, glacial;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Desert"))
        {
            thisMythos.biome = desert;
        }
        else if (other.gameObject.CompareTag("Glacial"))
        {
            thisMythos.biome = glacial;
        }
        else if (other.gameObject.CompareTag("Mountain"))
        {
            thisMythos.biome = mountain;
        }
        else if (other.gameObject.CompareTag("Darklands"))
        {
            thisMythos.biome = darklands;
        }
        else if (other.gameObject.CompareTag("Woodlands"))
        {
            thisMythos.biome = woodlands;
        }
    }
}
