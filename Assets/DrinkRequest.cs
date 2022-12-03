using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkRequest : MonoBehaviour
{

    private CustomerMovement custmov;
  

    [SerializeField] public GameObject bubblePrefab;

    [SerializeField] public GameObject customer;

    private GameObject request;



    public void RequestBlue(){

        request = Instantiate(bubblePrefab);
        request.transform.position = new Vector3(customer.transform.position.x + 1,customer.transform.position.y + 1);
        request.transform.SetParent(customer.transform);

        StartCoroutine(WaitPlease(5.0f));
        
    }


  IEnumerator WaitPlease(float timeToDrinkInSeconds) { //Waiting until the time runs out, and until the waitBoolean is false. 

       // Debug.Log(custmov.waitBoolean);
        yield return new WaitUntil(() => custmov.waitBoolean == false);
        yield return new WaitForSeconds(timeToDrinkInSeconds);
        custmov.waiting = false;
       
    }

    public GameObject returnCustomer(){
      return customer;
    }


    void Start()   { 

        custmov = GetComponent<CustomerMovement>();
     //   drinkLog = GetComponent<DrinkLogic>();

      }
    void Update() {  

   // if(Vector3.Distance(customer.transform.position, drinkLog.closestDrinkToCustomer().position) < 1){
    //  Debug.Log("Yippee!");
   //     custmov.waitBoolean = false;
  //  }

      checkForDrink();
    }


    private void checkForDrink() {

      if(custmov == null)
        return;
      
      Transform station = custmov.currentPosition.transform;
      Transform table, coaster, drink;

      if(station != null && 
        (station.childCount > 0 && (table = station.GetChild(0)) != null) && 
        (table.childCount > 0 && (coaster = table.GetChild(0)) != null) && 
        (coaster.childCount > 0 && (drink = coaster.GetChild(0)) != null)) {

          custmov.waitBoolean = false;
          Destroy(request);
      }
    }
}
