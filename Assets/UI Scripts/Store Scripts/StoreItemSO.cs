using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoreMenu", menuName = "Scriptable Objects/New Store Item", order = 1)]
public class StoreItemSO : ScriptableObject
{
    public string title;
    public string description;
    public int baseCost;
}
