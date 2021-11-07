using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] QuestList questList;
    private GameObject newQuestCanvas;
    private Text newQuestText;

    private void Start()
    {
        newQuestCanvas = Globals.NewQuestCanvas;
        newQuestText = newQuestCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
    }

    public void StartNewQuest(string questName)
    {
        foreach (Quest q in questList.Quests)
        {
            if (q.questName == questName && q.questState == QuestSate.Inactive)
            {
                newQuestText.text = "Nova missão: " + q.questName;
                newQuestCanvas.SetActive(true);
                AdvanceQuestStep(q);
                StartCoroutine(NewQuestCanvas());
            }
        }
    }

    public void AdvanceQuestStep(Quest quest)
    {
        quest.currentStep++;
    }

    public string GetQuestDialog(string interactionName)
    {
        foreach (Quest q in questList.Quests)
        {
            if(q.questState == QuestSate.Inactive || q.questState == QuestSate.Completed)
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
}
