using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : InventoryHolder

{
    [SerializeField] Fish fish;
    [SerializeField] private PlayerStats playerStats;

    private void Awake()
    {
        transform.position = new Vector3(0f, 1f, -5f);
    }

    private void Update()
    {
        if (playerStats.Inventory.invSystem != null)
        {
            this.inventorySystem = playerStats.Inventory.invSystem;
        }
    }
}
