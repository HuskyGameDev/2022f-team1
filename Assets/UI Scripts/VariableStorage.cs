using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class VariableStorage : MonoBehaviour
{
    public static int money=0;
    public static string barName = "Bar Name";

    public static VariableStorage instance;
    public TMP_InputField nameInputField;

        void Start()
    {
        //This is how it's done.

        if (VariableStorage.instance == null){
            VariableStorage.instance = this; 
            DontDestroyOnLoad(this);
        }
        gameObject.SetActive(false);
        
    }

    public void TempMoneyGain()
    {
        money = money + 10;
    }

    public void setName()
    {
        barName = nameInputField.text;
        nameInputField.text = null;
    }
}
