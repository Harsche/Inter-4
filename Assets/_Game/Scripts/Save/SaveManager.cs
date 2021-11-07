using System.Reflection;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public SaveFile saveFile { get; private set; }
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + @"\gamedata";
        saveFile = new SaveFile();
    }

    public void LoadGame()
    {
        string jsonSave = "";
        if (File.Exists(savePath)) jsonSave = File.ReadAllText(savePath);
        saveFile = JsonUtility.FromJson<SaveFile>(jsonSave);
    }

    public void SaveGame()
    {
        string jsonSave = JsonUtility.ToJson(saveFile);
        if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);
        File.WriteAllText(savePath, jsonSave);
    }

    public T GetValue<T>(string propertyName)
    {
        PropertyInfo property = saveFile.GetType().GetProperty(propertyName);
        if(property == null)
            return default(T);

        return (T)property.GetValue(saveFile);
    }

    public void SetValue<T>(string propertyName, T value)
    {
        PropertyInfo property = saveFile.GetType().GetProperty(propertyName);
        if(property != null)
        {
            property.SetValue(saveFile, value);
        }
    }
}

[System.Serializable]
public class SaveFile
{
    public bool house_01_opened;
    public bool house_02_opened;
    public bool house_03_opened;
    public bool house_04_opened;
    public bool house_05_opened;
    public bool house_06_opened;

    public SaveFile()
    {
        house_01_opened = true;
    }
}
