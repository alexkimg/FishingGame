using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStats
{
    public SaveData Inventory;
    public PlayerStats()
    {
        Inventory = new SaveData();
    }
    
}
