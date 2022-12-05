using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{

    //Just a starting script for y'all before I part.
    //Main goal being let this be an object that exists from the moment the game is started.
    public static BarManager instance;

    //It's close to due-date (actually past due) but I really wanted to crank something out before I turn in my progress report, which I'll fail but at least I won't get a zero.
    public GameObject ButtonManager;
    public GameObject MoneyManager;
    public GameObject DrinkManager;
    public GameObject CustomerManager;

    // Start is called before the first frame update
    void Start()
    {
        //This is how it's done.
        BarManager.instance = this; 
        DontDestroyOnLoad(this);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
