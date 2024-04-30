using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem inventorySystem;
    [SerializeField] LevelManager levelManager;

    private PlayerStats saveData = new PlayerStats();

    public InventorySystem InventorySystem => inventorySystem;

    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

    private void Awake()
    {
        inventorySystem = new InventorySystem(inventorySize);
    }
    private void Update()
    {
        saveData.Inventory.invSystem = inventorySystem;
    }
}

[System.Serializable]
public struct SaveData
{
    public InventorySystem invSystem;

    public SaveData(InventorySystem _invSystem)
    {
        invSystem = _invSystem;
    }
}
