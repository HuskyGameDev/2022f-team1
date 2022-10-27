using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class CustomerLogic : MonoBehaviour
{

    public List<GameObject> customerList = new List<GameObject>();
    public GameObject alien;
    

     public float MoveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;


    void Start()
    {

        customerList = GameObject.FindGameObjectsWithTag("Customer").ToList();
        alien = customerList[0];

        
    }


    void FixedUpdate()
    {
 
        while(Input.GetKey("m")){
            movement.x += 0.5f;
            movement.y -= 0.5f;
        } 
        
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
        //Moves the rigid body movement times speed, and then times the time inbetween the last method calls which ensures a consistent speed of running. (no gaps inbetween running clips)



    }
}
