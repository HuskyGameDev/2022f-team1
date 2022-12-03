using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class VariableStorage : MonoBehaviour
{
    public static int money=0;
    public static string barName = "Bar Name";
    public TMP_InputField nameInputField;

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
