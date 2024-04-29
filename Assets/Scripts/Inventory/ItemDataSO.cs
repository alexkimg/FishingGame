using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System / Inventory Item")]
public class ItemDataSO : ScriptableObject
{
    public string Name;
    public Sprite icon;
    public int Value;
    public int Quantity;
}

