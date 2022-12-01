using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    

    [SerializeField] bool holdingDrink;

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


        if(Input.GetKey("k")){
            if(animator.GetBool("holdingDrink") == false){
                animator.SetBool("holdingDrink",true);
            } else{
            animator.SetBool("holdingDrink",false);
            }
        }

/*
            if(Input.GetKey("y")){
                Debug.Log("ON");
                CustomerMovement.waitBoolean = true; } 
        if(Input.GetKey("u")){ 
            Debug.Log("OFF");
            CustomerMovement.waitBoolean = false;
        }

*/

    }

    //Fixed update is very reliable at 50 frames per second every single time. 
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
        //Moves the rigid body movement times speed, and then times the time inbetween the last method calls which ensures a consistent speed of running. (no gaps inbetween running clips) 

    }

}
