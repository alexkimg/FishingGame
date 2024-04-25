using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System / Inventory Item")]
public class ItemData : ScriptableObject
{
    public string Name;
    public int Value;
    public int Quantity;
}
