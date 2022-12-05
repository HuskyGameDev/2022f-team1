using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DrinkRequest))] //every time we call customer movement we NEED to have drink request. Every customer needs a drink request. 

public class CustomerMovement : MonoBehaviour
{
    
//GOAL: Have the customers go to a table and wait until a boolean is true/is activated (either by time limit or by service, make it toggleable)

//REMINDER: Every table cannot link to more tables or paths. 

//FUTURE NOTES:
// Make an individual boolean for waiting INSIDE THE NODE/STATION so that it can be modified individualistically, not just the entirety of all nodes.



public Station currentPosition;
private Station targetPosition;

private float neededDistance;

[SerializeField] private float walkSpeed;
[SerializeField] private float waitMultiplier = 1.0f;

public bool waitBoolean = false; //TO WORK ON

private bool moving, leaving;
public bool waiting;
private DrinkRequest e;



void Start() {

e = GetComponent<DrinkRequest>();

if (currentPosition == null)
    currentPosition = GameObject.Find("entranceWaypoint").GetComponent<Station>();

currentPosition.changeCapacity(true); 
this.transform.position = currentPosition.transform.position; 

waiting = true;
StartCoroutine(Wait(currentPosition.waitTime * waitMultiplier)); 

}

    void Update(){

        if(waiting){ return; }

////////////////////////////
//  Handles leaving/returning to the main parent (the entrance). 
////////////////////////////        

        if(!moving){

            if(targetPosition == null){

                if(leaving){
                    if(!currentPosition.parent.atCapacity()){
                        targetPosition = currentPosition.parent;
                        currentPosition.changeCapacity(false);
                        targetPosition.changeCapacity(true); //Premptively calls which space it wants and changes the capacity before it arrives.
                        neededDistance = Vector3.Distance(currentPosition.transform.position, targetPosition.transform.position);
                    }
                }
////////////////////////////
//  Handles finding tables, finding paths and setting target position of paths and tables. 
////////////////////////////
            else {
                    //Iterates through all available tables, finds first table that is not at capacity and sets it as the current goal.
                     foreach(Station table in currentPosition.tables) {

                     if(!table.atCapacity()) {
                        targetPosition = table;             //Table search and grab.
                        targetPosition.occupied = true;

                        currentPosition.changeCapacity(false); //Change to boolean table system here and below. 
                        targetPosition.changeCapacity(true);
                        neededDistance = Vector3.Distance(currentPosition.transform.position, targetPosition.transform.position);
                        break;
                     }
                    }

                    if(targetPosition == null) {

                    foreach(Station path in currentPosition.paths) {
                        if(!path.atCapacity()) {
                            targetPosition = path;          
                            currentPosition.occupied = false;

                            currentPosition.changeCapacity(false);
                            targetPosition.changeCapacity(true);
                            neededDistance = Vector3.Distance(currentPosition.transform.position, targetPosition.transform.position);
                            break;

                            }
                        }
                    }
                }
            } 
////////////////////////////
//  Handles movement, leaving and returning. 
////////////////////////////   

    else { moving = true;  }       //if target is NOT null, start movin!   
            } 
    else {          //Move the node position until the current position is equal to the target position 

        
       this.transform.position += (targetPosition.transform.position - currentPosition.transform.position).normalized * Time.deltaTime * walkSpeed;
       neededDistance -= Time.deltaTime * walkSpeed;  
    }

    if(moving && neededDistance <= 0.1f) {

        this.transform.position = targetPosition.transform.position;
        currentPosition = targetPosition;

        targetPosition = null;
        moving = false; 
        waiting = true;

        //If I hit the parent, or the table/end of the paths, then the leaving variable flips. 
        if((currentPosition.tables.Length == 0 && currentPosition.paths.Length == 0)){   
            
            leaving = !leaving;  
            waitBoolean = true;
            e.RequestBlue();

        } else if(currentPosition.parent == null) {

            CustomerManager.instance.RemoveCustomer(gameObject);
            Destroy(gameObject);

        } else {
                
            StartCoroutine(Wait(currentPosition.waitTime * waitMultiplier)); 
        }        
    }
    //End of update()
    }


    IEnumerator Wait(float time) { //Waiting until the time runs out.

        
        yield return new WaitForSeconds(time);
        waiting = false;
     
    }




}
