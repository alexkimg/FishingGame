using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewItemDatabase", menuName = "Inventory System/Database")]
public class ItemDatabaseSO : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemDataSO[] Items;
    public Dictionary<ItemDataSO, int> GetId = new Dictionary<ItemDataSO, int>();

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<ItemDataSO, int>();
        for (int i = 0; i < Items.Length; i++)
        {
            GetId.Add(Items[i], i);
        }
    }

    public void OnBeforeSerialize()
    {

    }
}

