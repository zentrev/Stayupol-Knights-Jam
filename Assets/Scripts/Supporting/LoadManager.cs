using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//C:\Users\Rowan Remy\AppData\LocalLow
//https://www.youtube.com/watch?v=BPu3oXma97Y
public class LoadManager : Singleton<LoadManager>
{
    public SaveData saveData;
    string dataFile = "506c6179657244617461.dat"; //PlayerData in hex

    private void Start()
    {
        Load();
    }

    public void Save()
    {
        UpdateSavedData();
        try
        {
            string filePath = Application.persistentDataPath + "/" + dataFile;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            bf.Serialize(file, saveData);
            file.Close();
        }
        catch (Exception e)
        {
            Debug.Log("Error in Saving:" + e.Message);
        }
    }

    public void UpdateSavedData()
    {
        try
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
            
                //Get Data To Save
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error in Updating save:" + e.Message);
        }
    }

    public void ResetSaveData()
    {
        saveData = new SaveData();

        try
        {
            string filePath = Application.persistentDataPath + "/" + dataFile;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            bf.Serialize(file, saveData);
            file.Close();
        }
        catch (Exception e)
        {
            Debug.Log("Error in Reset Saving:" + e.Message);
        }
    }

    public void Load()
    {
        string filePath = Application.persistentDataPath + "/" + dataFile;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(filePath))
        {
            try
            {
                FileStream file = File.Open(filePath, FileMode.Open);
                SaveData loaded = (SaveData)bf.Deserialize(file);
                saveData = loaded;
                file.Close();

                if (saveData == null)
                {
                    saveData = new SaveData();
                }
            }
            catch (Exception e)
            {
                Debug.Log("Error in Loading:" + e.Message);
                ResetSaveData();
            }
        }
        else
        {
            ResetSaveData();
        }
    }
    #region Serializable Objects

    [System.Serializable]
    public class SaveData
    {
        public float PlayerHealth;
       
        public SaveData()
        {
            PlayerHealth = 100;
        }

      
    }

    [System.Serializable]
    public class Vec3
    {
        public float x;
        public float y;
        public float z;
        public Vec3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Vec3(Vector3 pos)
        {
            x = pos.x;
            y = pos.y;
            z = pos.z;
        }
        public Vector3 ToVector()
        {
            return new Vector3(x, y, z);
        }
    }
    #endregion
}
