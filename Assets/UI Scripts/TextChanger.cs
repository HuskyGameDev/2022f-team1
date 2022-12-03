using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myMoneyTextElement;
    [SerializeField] private TextMeshProUGUI myBarNameTextElement;
    public int moneyTracker;
    public string nameTracker;

    void Start()
    {
        moneyTracker = VariableStorage.money;
        nameTracker = VariableStorage.barName;
        myMoneyTextElement.text = "Money=" + moneyTracker;
        myBarNameTextElement.text = nameTracker;
    }
    public void TempMoneyGainText()
    {
        moneyTracker = VariableStorage.money;
        myMoneyTextElement.text = "Money=" + moneyTracker;
    }

    public void nameChangeText()
    {
        nameTracker = VariableStorage.barName;
        myBarNameTextElement.text = nameTracker;
    }
}
