using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    private IDataService dataService = new JsonDataService();


    public void SaveData()
    {
       dataService.SaveData("/player-stats.json", playerStats);
    }

    public void LoadData()
    {

        PlayerStats data = dataService.LoadData<PlayerStats>("/player-stats.json");

    }



}
