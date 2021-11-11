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

    public GameObject moveCheck;
    public GameObject spaceFill;
    public GameObject movePosition;
    
    public Collectable thisMythos;
    public Collectable teamate;

    public float movement = 0;
    public bool canMove = true;

    public bool CanDrag { get; set; }
    public UnityEvent OnDrag;
    public UnityEvent OnUp; 
    public bool Draggable { get; set; }

    private void Start()
    {
        cam = Camera.main;
        Draggable = true;
        movement = thisMythos.speed;
        thisMythos.canAttack = false;
    }

    private void Update()
    {
        teamate.canAttack = thisMythos.canAttack;
    }

    public IEnumerator OnMouseDown()
    {
        if (canMove == true)
        {
            movePositionData.value = moveCheck.transform.position;
            scaleData.value = transform.localScale;
            teamate.characterFight = thisMythos.characterFight;
            teamate.power = thisMythos.power;
            teamate.defense = thisMythos.defense;
            teamate.biome = thisMythos.biome;
            teamate.attackIcon = thisMythos.attackIcon;
            teamate.charSprite = thisMythos.charSprite;
            teamate.special = thisMythos.special;
            teamate.canAttack = thisMythos.canAttack;

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
                moveCheck.transform.position = movePositionData.value;
                spaceFill.transform.position = movePositionData.value;
            }
        }
    }
    
    private IEnumerator OnMouseUp()
    {
        if (canMove == true)
        {
            teamate.biome = thisMythos.biome;
            teamate.canAttack = thisMythos.canAttack;

            CanDrag = false;
            yield return new WaitForFixedUpdate();
            transform.position = positionData.value;
        
            moveCheck.SetActive(false);
            movePosition.SetActive(false);
        
            moveCheck.transform.position = movePositionData.value;
            spaceFill.transform.position = movePositionData.value;
            transform.localScale = scaleData.value;

            movement += -1;

            if (Draggable)
            {
                OnUp.Invoke();
            }
        }
        
        
        if (movement == 0)
        {
            canMove = false;
        }
    }

    public void Move()
    {
        transform.position = newSpace.value;
    }

}

