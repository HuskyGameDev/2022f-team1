using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DrinkLogic : MonoBehaviour
{

    
    public PlayerMovement playerMovement;
    public DrinkRequest drinkQue;
    public Transform hand, coaster;
    public Transform drink;
    public Animator animator;
    
    public float drinkReach = 1.5f;

    public KeyCode pickUpKey = KeyCode.O, putDownKey = KeyCode.P;

    public List<GameObject> coasterList = new List<GameObject>();
    public List<GameObject> drinkList = new List<GameObject>();

  
    void Start(){

        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        coasterList = GameObject.FindGameObjectsWithTag("Coaster").ToList();
        drinkList = GameObject.FindGameObjectsWithTag("Drink").ToList();
        //Debug.Log(coasterList[0]);
        //Debug.Log(coasterList[1]);

        drinkQue = GetComponent<DrinkRequest>();
    }


    void FixedUpdate(){

        if(Input.GetKey(putDownKey)){
            if(playerMovement.holdingDrink && closeEnough()){
                ToggleDrinkPosition();
            }

            
        }

        if(Input.GetKey(pickUpKey)){
            if(!playerMovement.holdingDrink && closeEnough()){
                ToggleDrinkPosition();
            }

            
        }


    }

    void ToggleDrinkPosition() {

        if (!playerMovement.holdingDrink) {
            closestDrink().transform.parent = hand;
            playerMovement.holdingDrink = true;
        } else {
            closestDrink().transform.parent = closestCoaster().transform;
            playerMovement.holdingDrink = false;
        }

        closestDrink().transform.localPosition = Vector3.zero;
        closestDrink().transform.localScale = Vector3.one;
    }

    bool closeEnough(){

        if (Vector3.Distance (hand.position, closestCoaster().transform.position) < drinkReach) { return true; } 
        else{  return false; } 
    }



    GameObject closestCoaster(){

        //Cycles through the list of current coasters and finds the one with the smallest distance between the hand and the coaster.
    GameObject closest = coasterList[0];

    for(int i = 0; i < coasterList.Count; i++){
    if(Vector3.Distance(hand.position, coasterList[i].transform.position) < Vector3.Distance(hand.position, closest.transform.position)){
        closest = coasterList[i];
    }}
    return closest;
    }



    GameObject closestDrink(){
        //Cycles through list of current drinks and finds the one with the smallest distance between the hand and the drink. 
        GameObject closest = drinkList[0];

        for(int i = 0; i < drinkList.Count; i++){
           if(Vector3.Distance(hand.position, drinkList[i].transform.position) < Vector3.Distance(hand.position, closest.transform.position)){
        closest = drinkList[i]; 
        }}
        return closest;
    }

    public Transform closestDrinkToCustomer(){
        //Cycles through list of current drinks and finds the one with the smallest distance between the hand and the drink. 
        GameObject closest = drinkList[0];

        for(int i = 0; i < drinkList.Count; i++){
           if(Vector3.Distance(drinkQue.customer.transform.position, drinkList[i].transform.position) < Vector3.Distance(hand.position, closest.transform.position)){
        closest = drinkList[i]; 
        }}
        return closest.transform;
    }

}
