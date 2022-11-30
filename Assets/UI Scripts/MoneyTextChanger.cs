using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyTextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;
   public int moneyTracker;
    void Start()
    {
        moneyTracker = MoneyVariableStorage.money;
        myTextElement.text = "Money=" + moneyTracker;
    }
    public void TempMoneyGainText()
    {
        moneyTracker = MoneyVariableStorage.money;
        myTextElement.text = "Money=" + moneyTracker;
    }
}
