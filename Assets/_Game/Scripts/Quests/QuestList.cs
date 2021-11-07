using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/QuestList")]
public class QuestList : ScriptableObject
{
    [SerializeField] private Quest[] quests;

    public Quest[] Quests
    {
        get => quests;
    }

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
