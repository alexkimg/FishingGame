using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonDataService : IDataService
{

    public bool SaveData<T>(string RelativePath, T Data)
      {
        string path = Application.persistentDataPath + RelativePath;

        if (File.Exists(path))
        {
            try
            {
                File.Delete(path);
                using FileStream stream = File.Create(path);
                stream.Close();
                File.WriteAllText(path, JsonConvert.SerializeObject(Data));
                return true;
            }
            catch (Exception exception)
            {
                Debug.LogError($"Unable to save due to: {exception.Message}");
                return false;
            }
        } 
        else
        {
            try
            {
                using FileStream stream = File.Create(path);
                stream.Close();
                File.WriteAllText(path, JsonConvert.SerializeObject(Data));
                return true;
            }
            catch (Exception exception)
            {
                Debug.LogError($"Unable to save due to: {exception.Message}");
                return false;
            }
        }

      }

    //public T LoadData<T>(string RelativePath)
    //{

    //}
}
