using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour {

    public static CustomerManager instance;

    [SerializeField] private GameObject[] customerPrefabs;

    private List<GameObject> customers = new List<GameObject>();

    [SerializeField] private Transform customerFolder;

    public float rate;
    public float maxOccupancy;

    private System.Random rand;
    private bool delaying;

    void Start() {

        if (CustomerManager.instance == null){
            CustomerManager.instance = this; 
            DontDestroyOnLoad(this);
        }
        gameObject.SetActive(false);

        rand = new System.Random();
        delaying = false;
    }

    void Update() {

        if (customers.Count < maxOccupancy && !delaying) {

            GenerateCustomer();
            StartCoroutine(Wait(rate));
        }
    }

    public void RemoveCustomer(GameObject customer) { customers.Remove(customer); }

    private void GenerateCustomer() {

        int randIndex = rand.Next(0, customerPrefabs.Length);
        customers.Add(Instantiate(customerPrefabs[randIndex], customerFolder));
    }

    private IEnumerator Wait(float delayInSeconds) {

        delaying = true;
        yield return new WaitForSeconds(delayInSeconds);
        delaying = false;
    }
}
