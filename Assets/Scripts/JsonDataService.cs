using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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

    public T LoadData<T>(string RelativePath)
    {
        string path = Application.persistentDataPath + RelativePath;

        if (!File.Exists(path))
        {
            Debug.LogError($"Cannot load file at {path}. File does not exist!");
            throw new FileNotFoundException($"{path} does not exist!");
        }

        try
        {
           
            T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return data;
        }
        catch (Exception exception)
        {
            Debug.LogError($"Failed to load data due to: {exception.Message}");
            throw exception;
        }

    }
}
