using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmployeeMenu", menuName = "Scriptable Objects/New Employee Item", order = 1)]
public class EmployeeSO : ScriptableObject
{
    public string employeeName;
    public string employeeDescription;
    public int HireCost;

}
