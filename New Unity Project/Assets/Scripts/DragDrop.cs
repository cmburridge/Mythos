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
    public GameObject undo;
    public GameObject attackCheck;
    public GameObject rangeCheck;
    
    public Collectable thisMythos;
    public Collectable teamate;

    public float movement = 0;
    public bool canMove = true;

    public AudioSource audioClip;

    public bool CanDrag { get; set; }
    public UnityEvent OnDrag;
    public UnityEvent OnUp; 
    public bool Draggable { get; set; }

    private void Start()
    {
        cam = Camera.main;
        Draggable = true;
        thisMythos.canMove = true;
        thisMythos.collected = true;
        movement = thisMythos.speed;
        thisMythos.hp = thisMythos.maxHp;
        thisMythos.canAttack = false;
        thisMythos.turnOver = false;
    }
    private void Update()
    {
        if (teamate.turnStart == true)
        {
            thisMythos.canMove = true;
            movement = thisMythos.speed;
            thisMythos.turnOver = false;
        }
        
        if (thisMythos.turnOver == true)
        {
            attackCheck.SetActive(false);
            rangeCheck.SetActive(false);
        }
        else
        {
            attackCheck.SetActive(true);
            rangeCheck.SetActive(true);
        }
    }

    public IEnumerator OnMouseDown()
    {
        if (thisMythos.canMove == true)
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
            teamate.turnStart = false;
            spaceFill.SetActive(false);

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
        if (thisMythos.canMove == true)
        {
            audioClip.Play();
            teamate.biome = thisMythos.biome;
            teamate.canAttack = thisMythos.canAttack;
            spaceFill.SetActive(true);

            CanDrag = false;
            yield return new WaitForFixedUpdate();
            transform.position = positionData.value;
            
        
            moveCheck.SetActive(false);
            movePosition.SetActive(false);
            undo.SetActive(true);
        
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
            thisMythos.canMove = false;
        }
    }

    public void Move()
    {
        transform.position = newSpace.value;
    }

    public void Undo()
    {
        undo.SetActive(false);
        movement += 1;
        thisMythos.canMove = true;
        transform.position = positionData.value;
    }
}

