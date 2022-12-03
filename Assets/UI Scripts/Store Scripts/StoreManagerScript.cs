using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StoreManagerScript : MonoBehaviour
{
    public int sceneToLoad;
    public int currentMoney;
    public TMP_Text storeMoneyUI;
    public StoreItemSO[] storeItemSO;
    public GameObject[] storePanelsGO;
    public StoreTemplateScript[] storePanels;
    public Button[] myPurchaseBtns;


    void Start()
    {
        for (int i = 0; i < storeItemSO.Length; i++)
            storePanelsGO[i].SetActive(true);

        currentMoney = VariableStorage.money;
        storeMoneyUI.text = "Money = " + VariableStorage.money;
        LoadPanels();
        CheckPurchaseable();
    }

    //Button Functionality for the Exit Button
    public void ExitOnPress()
    {
        sceneToLoad = 0;

        SceneManager.LoadScene(sceneToLoad);
    }

    public void CheckPurchaseable()
    {
        for(int i=0; i<storeItemSO.Length; i++)
        {
            if (currentMoney >= storeItemSO[i].baseCost)
            {
                myPurchaseBtns[i].interactable = true;
            }
            else
            {
                myPurchaseBtns[i].interactable = false;
            }
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (currentMoney >= storeItemSO[btnNo].baseCost)
        {
            VariableStorage.money = VariableStorage.money - storeItemSO[btnNo].baseCost;
            currentMoney = VariableStorage.money;
            storeMoneyUI.text = "Money = " + currentMoney.ToString();
            CheckPurchaseable();
        }
    }

    public void LoadPanels()
    {
        for(int i = 0; i < storeItemSO.Length; i++)
        {
            storePanels[i].titleTxt.text = storeItemSO[i].title;
            storePanels[i].descriptionTxt.text = storeItemSO[i].description;
            storePanels[i].costTxt.text = "Buy: " + storeItemSO[i].baseCost.ToString();
        }
    }
}
