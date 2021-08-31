using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragDrop : MonoBehaviour
{
    public void OnMouseDrag()
    {
		
        transform.Translate(Vector3.right*Input.GetAxis("Mouse X"));
    }
}
