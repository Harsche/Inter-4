using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager
{
    public static SaveFile saveFile { get; private set; } = new SaveFile();
    private static string savePath = Application.persistentDataPath + @"\gamedata.json";

    public static void LoadGame()
    {
        string jsonSave = "";
        if (File.Exists(savePath))
            jsonSave = File.ReadAllText(savePath);
        saveFile = JsonConvert.DeserializeObject<SaveFile>(jsonSave);
    }

    public static void SaveGame()
    {
        string jsonSave =  JsonConvert.SerializeObject(saveFile);
        if (!Directory.Exists(Path.GetDirectoryName(savePath))) Directory.CreateDirectory(Path.GetDirectoryName(savePath));
            File.WriteAllText(savePath, jsonSave);
    }

    public static T GetData<T>(string guid) where T : ObjectData
    {
        return (T)saveFile.GetData<T>(guid);
    }

    public static void SaveData(string guid, ObjectData data)
    {
        saveFile.AddData(guid, data);
    }
}

[System.Serializable]
public class ObjectData {}

[System.Serializable]
public class SaveFile : ISerializationCallbackReceiver
{
    public Dictionary<string, ObjectData> data = new Dictionary<string, ObjectData>();
    [SerializeField] private List<string> dataKeys = new List<string>();
    [SerializeField] private List<ObjectData> dataValues = new List<ObjectData>();

    public SaveFile() { }

    public void OnBeforeSerialize()
    {
        dataKeys.Clear();
        dataValues.Clear();
        foreach (KeyValuePair<string, ObjectData> dataPair in data)
        {
            dataKeys.Add(dataPair.Key);
            dataValues.Add(dataPair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        Dictionary<string, ObjectData> dataDictionary = new Dictionary<string, ObjectData>();
        for (int i = 0; i < Mathf.Min(dataKeys.Count, dataValues.Count); i++)
        {
            dataDictionary.Add(dataKeys[i], dataValues[i]);
        }
    }

    public bool Contains(string id)
    {
        if (!data.ContainsKey(id))
            return false;
        return true;
    }

    public void AddData(string key, ObjectData value)
    {
        if(!data.ContainsKey(key))
        {
            data.Add(key, value);
            return;
        }
        data[key] = value;
    }

    public T GetData<T>(string id) where T : ObjectData
    {
        if (!data.ContainsKey(id))
            return default(T);
        return (T)data[id];
    }
}
