using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkRequest : MonoBehaviour
{

    public CustomerMovement custmov;
  

    [SerializeField] public GameObject bubblePrefab;

     [SerializeField] public GameObject customer;




    public void RequestBlue(){

         GameObject request = Instantiate(bubblePrefab);
        request.transform.position = new Vector3(customer.transform.position.x + 1,customer.transform.position.y + 1);
        request.transform.SetParent(customer.transform);

        StartCoroutine(WaitPlease(1));
        
    }


  IEnumerator WaitPlease(float time) { //Waiting until the time runs out, and until the waitBoolean is false. 

       // Debug.Log(custmov.waitBoolean);
         yield return new WaitForSeconds(time);
        yield return new WaitUntil(() => custmov.waitBoolean == false);
        yield return new WaitForSeconds(time);
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

    }



}
