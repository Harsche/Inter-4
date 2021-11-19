using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObjects/QuestList")]
public class QuestList : ScriptableObject
{
    public Quest[] quests;

    [ContextMenu("Reset quests")]
    public void ResetQuests()
    {
        foreach(Quest q in quests)
        {
            q.questState = QuestSate.Inactive;
            q.currentStep = 0;
        }
    }
}
