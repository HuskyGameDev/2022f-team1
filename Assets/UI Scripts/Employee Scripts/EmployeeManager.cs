using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EmployeeManager : MonoBehaviour
{
    public int sceneToLoad;
    public int currentMoney;
    public TMP_Text employeeMoneyUI;
    public EmployeeSO[] employeeSO;
    public GameObject[] employeePanelsGO;
    public EmployeeTemplateScript[] employeePanels;
    public Button[] myHireBtns;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < employeeSO.Length; i++)
        {
            employeePanelsGO[i].SetActive(true);
        }

            currentMoney = VariableStorage.money;
        employeeMoneyUI.text = "Money = " + VariableStorage.money;
        LoadPanels();
        CheckHireable();
    }

    //Button Functionality for the Exit Button
    public void ExitOnPress()
    {
        sceneToLoad = 0;

        SceneManager.LoadScene(sceneToLoad);
    }

    public void CheckHireable()
    {
        for(int i=0; i < employeeSO.Length; i++)
        {
            if(currentMoney >= employeeSO[i].HireCost)
            {
                myHireBtns[i].interactable = true;
            }
            else
            {
                myHireBtns[i].interactable = false;
            }
        }
    }

    public void HireEmployee(int btnNo)
    {
        if(currentMoney >= employeeSO[btnNo].HireCost)
        {
            VariableStorage.money = VariableStorage.money - employeeSO[btnNo].HireCost;
            currentMoney = VariableStorage.money;
            employeeMoneyUI.text = "Money = " + currentMoney.ToString();
            CheckHireable();
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < employeeSO.Length; i++)
        {
            employeePanels[i].employeeNameTxt.text = employeeSO[i].employeeName;
            employeePanels[i].employeeDescriptionTxt.text = employeeSO[i].employeeDescription;
            employeePanels[i].employeeCostTxt.text = "Buy: " + employeeSO[i].HireCost.ToString();
        }
    }
}
