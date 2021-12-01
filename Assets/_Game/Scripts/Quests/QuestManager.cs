using CleverCrow.Fluid.UniqueIds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private QuestList questList;
    [SerializeField] private TasksMenu tasksMenu;
    private string myGuid;
    public QuestData questData { get; private set; }
    private GameObject newQuestCanvas;
    private Text newQuestText;

    private void Start()
    {
        SaveManager.SaveAllData += SaveQuestData;
        myGuid = GetComponent<UniqueId>().Id;
        questData = SaveManager.GetData<QuestData>(myGuid);
        newQuestCanvas = Globals.NewQuestCanvas;
        newQuestText = newQuestCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        tasksMenu.InstantiateTaskMenu();
        if (questData != null)
        {
            questList = questData.questList;
            foreach (string task in questData.tasks)
            {
                TasksMenu.Instance.AddTask(task);
            }
            return;
        }
        questData = new QuestData();
    }

    public void StartNewQuest(string questName)
    {
        if(questData.tasks.Contains(questName))
            return;
        ShowQuestOnCanvas(questName);
        questData.tasks.Add(questName);
        TasksMenu.Instance.AddTask(questName);

        /*
        foreach (Quest q in questList.quests)
        {
            if (q.questName == questName && q.questState == QuestSate.Inactive)
            {
                newQuestText.text = q.questName;
                newQuestCanvas.SetActive(true);
                AdvanceQuestStep(q);
                StartCoroutine(NewQuestCanvas());
            }
        }
        */
    }

    public void RemoveQuest(string taskName)
    {
        questData.tasks.Remove(taskName);
        TasksMenu.Instance.RemoveTask(taskName);
    }

    public void ShowQuestOnCanvas(string questName)
    {
        newQuestText.text = questName;
        newQuestCanvas.SetActive(true);
        StartCoroutine(NewQuestCanvas());
    }

    public void AdvanceQuestStep(Quest quest)
    {
        quest.currentStep++;
    }

    public string GetQuestDialog(string interactionName)
    {
        foreach (Quest q in questList.quests)
        {
            if (q.questState == QuestSate.Inactive || q.questState == QuestSate.Completed)
            {
                continue;
            }

            QuestStep step = q.questSteps[q.currentStep];
            switch (step.questType)
            {
                case QuestType.TalkTo:
                    if (step.goalName == interactionName)
                    {
                        string knot = FormatToInkName(q.questName) + ".D" + (q.currentStep + 1).ToString("00");
                        return knot;
                    }
                    else
                    {
                        continue;
                    }

                case QuestType.NumberedTask:
                    return "";
            }
        }

        return FormatToInkName(interactionName);
    }

    private string FormatToInkName(string name)
    {
        return name.Replace(' ', '_');
    }

    IEnumerator NewQuestCanvas()
    {
        yield return (new WaitForSeconds(3.0f));
        newQuestCanvas.SetActive(false);
    }

    public void SaveQuestData()
    {
        questData.questList = questList;
        SaveManager.SaveData(myGuid, questData);
    }
}

public class QuestData : ObjectData
{
    public QuestList questList;
    public List<string> tasks = new List<string>();
}
