using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DrinkLogic : MonoBehaviour
{

    public Transform hand, coaster;
    public Transform drink;
    public Animator animator;
    
    public List<GameObject> coasterList = new List<GameObject>();
    public List<GameObject> drinkList = new List<GameObject>();

  
    void Start(){

        coasterList = GameObject.FindGameObjectsWithTag("Coaster").ToList();
        drinkList = GameObject.FindGameObjectsWithTag("Drink").ToList();
        //Debug.Log(coasterList[0]);
        //Debug.Log(coasterList[1]);
        
    }


    void FixedUpdate(){

        if(Input.GetKey("p")){
            if(animator.GetBool("holdingDrink") && closeEnough()){
                animator.SetBool("holdingDrink",false);
                ToggleDrinkPosition();
            }

            
        }

        if(Input.GetKey("o")){
            if((animator.GetBool("holdingDrink") == false) && closeEnough()){
                animator.SetBool("holdingDrink",true);
                ToggleDrinkPosition();
            }

            
        }


    }

    void ToggleDrinkPosition() {

        if (animator.GetBool("holdingDrink"))
            closestDrink().transform.parent = hand;
        else
            closestDrink().transform.parent = closestCoaster().transform; ///////

        closestDrink().transform.localPosition = Vector3.zero;
        closestDrink().transform.localScale = Vector3.one;
    }

    bool closeEnough(){

        if (Vector3.Distance (hand.position, closestCoaster().transform.position) < 1) { return true; } 
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

}
