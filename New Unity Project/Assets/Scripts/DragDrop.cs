using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Animations;


public class DragDrop : MonoBehaviour
{
    private Vector3 offsetPosition;
    private Vector3 newPosition;
    public Vector3 newScale;
    private Camera cam;
    
    public Vector3Data positionData;
    public Vector3Data movePositionData;
    public Vector3Data scaleData;
    public Vector3Data newSpace;
    public Vector3Data undoPosition;
    
    public GameObject moveCheck;
    public GameObject movePosition;
    //public GameObject undoButton;
    //public GameObject buttons;

    public Collectable thisMythos;

    public ObjectData obj;

    public bool CanDrag { get; set; }
    public UnityEvent OnDrag;
    public UnityEvent OnUp; 
    public bool Draggable { get; set; }

    private void Start()
    {
        cam = Camera.main;
        Draggable = true;
        obj.data = null;
    }
    
    public IEnumerator OnMouseDown()
    {
        movePositionData.value = moveCheck.transform.position;
        scaleData.value = transform.localScale;
        obj.data = this.gameObject;

        OnDrag.Invoke();
        offsetPosition = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForFixedUpdate();
        CanDrag = true;
        positionData.value = transform.position;
        while (CanDrag)
        {
            yield return new WaitForFixedUpdate();
            newPosition = cam.ScreenToWorldPoint(Input.mousePosition) + offsetPosition;
            transform.position = newPosition;
            transform.localScale = newScale;
            moveCheck.SetActive(true);
            movePosition.SetActive(true);
            //undoButton.SetActive(true);
            moveCheck.transform.position = movePositionData.value;
        }
    }
    
    private IEnumerator OnMouseUp()
    {
        CanDrag = false;
        yield return new WaitForFixedUpdate();
        transform.position = positionData.value;
        moveCheck.SetActive(false);
        movePosition.SetActive(false);
        moveCheck.transform.position = movePositionData.value;
        undoPosition.value = positionData.value;
        transform.localScale = scaleData.value;
        if (Draggable)
        {
            OnUp.Invoke();
        }
    }

    public void Move()
    {
        transform.position = newSpace.value;
    }

    public void Undo()
    {
        transform.position = undoPosition.value;
        //undoButton.SetActive(false);
    }
}

