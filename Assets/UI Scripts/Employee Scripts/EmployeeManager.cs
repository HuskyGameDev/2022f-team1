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
    public Button[] leftHireBtns;
    public Button[] rightHireBtns;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < employeeSO.Length; i++)
        {
            employeePanelsGO[i].SetActive(true);
            if (employeeSO[i].hasRight != true)
            {
                employeePanels[i].rightEmployee.SetActive(false);
            }
        }

            currentMoney = MoneyVariableStorage.money;
        employeeMoneyUI.text = "Money = " + MoneyVariableStorage.money;
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
            if(currentMoney >= employeeSO[i].leftHireCost)
            {
                leftHireBtns[i].interactable = true;
            }
            else
            {
                leftHireBtns[i].interactable = false;
            }

            if (employeeSO[i].hasRight)
            {
                if (currentMoney >= employeeSO[i].rightHireCost)
                {
                    rightHireBtns[i].interactable = true;
                }
                else
                {
                    rightHireBtns[i].interactable = false;
                }
            }
        }
    }

    public void HireLeftEmployee(int btnNo)
    {
        if(currentMoney >= employeeSO[btnNo].leftHireCost)
        {
            MoneyVariableStorage.money = MoneyVariableStorage.money - employeeSO[btnNo].leftHireCost;
            currentMoney = MoneyVariableStorage.money;
            employeeMoneyUI.text = "Money = " + currentMoney.ToString();
            CheckHireable();
        }
    }

    public void HireRightEmployee(int btnNo)
    {
        if (currentMoney >= employeeSO[btnNo].rightHireCost)
        {
            MoneyVariableStorage.money = MoneyVariableStorage.money - employeeSO[btnNo].rightHireCost;
            currentMoney = MoneyVariableStorage.money;
            employeeMoneyUI.text = "Money = " + currentMoney.ToString();
            CheckHireable();
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < employeeSO.Length; i++)
        {
            employeePanels[i].leftNameTxt.text = employeeSO[i].leftName;
            employeePanels[i].leftDescriptionTxt.text = employeeSO[i].leftDescription;
            employeePanels[i].leftCostTxt.text = "Buy: " + employeeSO[i].leftHireCost.ToString();

            employeePanels[i].rightNameTxt.text = employeeSO[i].rightName;
            employeePanels[i].rightDescriptionTxt.text = employeeSO[i].rightDescription;
            employeePanels[i].rightCostTxt.text = "Buy: " + employeeSO[i].rightHireCost.ToString();
        }
    }
}
