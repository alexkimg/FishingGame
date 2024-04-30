using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : InventoryHolder

{
    [SerializeField] private PlayerStats playerStats;

    protected override void LoadInventory(PlayerStats playerStats)
    {
        if( playerStats.Inventory.invSystem != null)
        {
            this.inventorySystem = playerStats.Inventory.invSystem;
        }
    }

<<<<<<< Updated upstream
    private void Update()
    {
        if (playerStats.Inventory.invSystem != null)
        {
            this.inventorySystem = playerStats.Inventory.invSystem;
        }
    }
=======
>>>>>>> Stashed changes
}
