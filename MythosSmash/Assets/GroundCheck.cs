using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour
{
    public UnityEvent isGrounded;
    public UnityEvent notGrounded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded.Invoke();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        notGrounded.Invoke();
    }
}
