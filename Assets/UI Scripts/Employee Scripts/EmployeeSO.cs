using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmployeeMenu", menuName = "Scriptable Objects/New Employee Item", order = 1)]
public class EmployeeSO : ScriptableObject
{
    public string leftName;
    public string leftDescription;
    public int leftHireCost;

    public bool hasRight;

    public string rightName;
    public string rightDescription;
    public int rightHireCost;

}
