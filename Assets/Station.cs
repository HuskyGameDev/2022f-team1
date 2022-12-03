using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
//
/*
    The purpose of this class is to make the waypoints where customers can be stationed visible with red dots, to show where they can go/access
    from the waypoints with the indicated red lines. 

    This class also stores the parents (the paths it traversed/connected to), the available tables around it, the available paths around it, 
    the wait time, the maximum capacity of the individual node, and the current capacity of the individual node. 
*/

  public Station parent; 
  public Station[] tables;
  public Station[] paths;

  public int waitTime = 3;

  public bool occupied = false;
  public bool hasOccupancyCap = false;

  
// The change capacity is used when leaving or going to tables/paths. It changes the capacity of it so multiple customers don't sit at the same table.
public void changeCapacity(bool value) { occupied = value; } 

//A boolean to check if the current capacity is at or exceeding the maximum capacity set on the node. 
public bool atCapacity() { return hasOccupancyCap ? occupied : false; } 


  //Draws the red circles onto the Stations, and the red lines onto the Paths.
    void OnDrawGizmos() {

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 0.25f);

        if(parent != null) {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position, parent.transform.position); //Makes a line from the station to it's parent
        }

        foreach(Station n in tables) {

            Gizmos.color = Color.green;
            Gizmos.DrawLine(this.transform.position, n.transform.position); //Draws a line from station to tables
        }

        foreach(Station n in paths) {

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(this.transform.position, n.transform.position); //Draws lines for paths from station
        }
        //
    }
}
