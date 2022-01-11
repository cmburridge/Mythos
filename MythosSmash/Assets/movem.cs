using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movem : MonoBehaviour
{
    public float acceleration;
    public float deceleration;
    public float gravity;

    public Vector3 constraint;
 
    private Rigidbody2D physics;
    private Vector2 input;
 
    public void Start() 
    {
        physics = GetComponent<Rigidbody2D>();
        physics.gravityScale = gravity;
        physics.drag = deceleration;
    }
 
    public void Update() 
    {
        input.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            input.y = Input.GetAxis("Vertical");
        }
    }

    public void IsGrounded()
    {
        physics.gravityScale = 0;
        input.y = Input.GetAxis("Vertical");
    }
    
    public void NotGrounded()
    {
        physics.gravityScale = gravity;
    }
    
    public void FixedUpdate() {
        physics.AddForce(input * acceleration * Time.deltaTime, ForceMode2D.Impulse);
    }
}
