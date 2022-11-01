using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyTextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;
   public int moneyTracker = 0;

    public void TempMoneyGain()
    {
        moneyTracker = moneyTracker + 10;
        myTextElement.text = "Money=" + moneyTracker;
    }
}
