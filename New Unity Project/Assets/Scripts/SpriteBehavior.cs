using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehavior : MonoBehaviour
{
    public SpriteRenderer ren;
    public Sprite newSprite;
    public Sprite ogSprite;
    private void OnTriggerEnter2D(Collider2D other)
    {
        ren.sprite = newSprite;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ren.sprite = ogSprite;
    }
}
