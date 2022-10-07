using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;


    //Update is unreliable for physics because varying framerate, but excellent for input. 
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.sqrMagnitude >= 0.01)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    //Fixed update is very reliable at 50 frames per second every single time. 
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
        //Moves the rigid body movement times speed, and then times the time inbetween the last method calls which ensures a consistent speed of running. (no gaps inbetween running clips) 

    }

}
