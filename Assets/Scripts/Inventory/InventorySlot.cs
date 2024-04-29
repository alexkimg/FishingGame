using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private ItemDataSO itemData;
    [SerializeField] private int stackSize;

    public ItemDataSO ItemData => itemData;
    public int StackSize => stackSize; 

    public InventorySlot(ItemDataSO source, int amount)
    {
        itemData = source;
        stackSize = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemData = null;
        stackSize = -1;
    }


    public void AddToStack(int amount)
    {
        stackSize += amount;
    }

    public void RemoveFromStack(int amount)
    {
        stackSize -= amount;
    }

    public void UpdateInventorySlot(ItemDataSO data, int amount)
    {
        itemData = data;
        stackSize = amount;
    }
}
