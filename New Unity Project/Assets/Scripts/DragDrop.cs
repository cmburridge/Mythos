using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DragDrop : MonoBehaviour
{
    private Vector3 offsetPosition;
    private Vector3 newPosition;
    private Camera cam;
    public Vector3Data positionData;
    public Vector3 newScale;

    public bool CanDrag { get; set; }
    public UnityEvent OnDrag;
    public UnityEvent OnUp;
    public bool Draggable { get; set; }

    private void Start()
    {
        cam = Camera.main;
        Draggable = true;
    }
    
    public IEnumerator OnMouseDown()
    {
        OnDrag.Invoke();
        positionData.value = transform.position;
        offsetPosition = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForFixedUpdate();
        CanDrag = true;
        while (CanDrag)
        {
            yield return new WaitForFixedUpdate();
            newPosition = cam.ScreenToWorldPoint(Input.mousePosition) + offsetPosition;
            transform.position = newPosition;
            transform.localScale = newScale;
        }
    }
    
    private void OnMouseUp()
    {
        transform.position = positionData.value;
        CanDrag = false;
        if (Draggable)
        {
            OnUp.Invoke();
        }
    }
}

