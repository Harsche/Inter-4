using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TasksMenu : MonoBehaviour
{
    [SerializeField] private GameObject questPanel;
    [SerializeField] private GameObject questInfo;
    public static TasksMenu Instance { get; private set; }
    private Dictionary<string, GameObject> taskDictionary = new Dictionary<string, GameObject>();

    public void InstantiateTaskMenu()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddTask(string taskName)
    {
        GameObject quest = Instantiate(questInfo, Vector3.zero, Quaternion.identity);
        quest.transform.SetParent(questPanel.transform, false);
        Text questText = quest.transform.GetChild(0).gameObject.GetComponent<Text>();
        questText.text = taskName;
        if(!taskDictionary.ContainsKey(taskName))
            taskDictionary.Add(taskName, quest);
    }

    public void RemoveTask(string taskName)
    {
        if (taskDictionary.ContainsKey(taskName))
        {
            GameObject objToDestroy = taskDictionary[taskName];
            taskDictionary.Remove(taskName);
            Destroy(objToDestroy);
        }
    }
}
