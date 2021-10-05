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
        foreach(Quest q in questList.MainQuests)
        {
            if(q.QuestName == questName && q.QuestState == QuestSate.Inactive)
            {
                newQuestText.text = "Nova missão: " + q.QuestName;
                q.QuestState = QuestSate.Active;
                newQuestCanvas.SetActive(true);
                StartCoroutine(NewQuestCanvas());
            }
        }
    }

    IEnumerator NewQuestCanvas()
    {
        yield return (new WaitForSeconds(3.0f));
        newQuestCanvas.SetActive(false);
    }
}
