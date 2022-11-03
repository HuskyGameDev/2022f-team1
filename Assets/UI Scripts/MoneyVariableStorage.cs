using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyVariableStorage : MonoBehaviour
{
    public static int money=0;

    public void TempMoneyGain()
    {
        money = money + 10;
    }
}
