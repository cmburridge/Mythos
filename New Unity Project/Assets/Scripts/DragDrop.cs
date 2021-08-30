using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
    }
}
