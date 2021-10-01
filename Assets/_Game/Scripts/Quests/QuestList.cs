using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/QuestList")]
public class QuestList : ScriptableObject
{
    [SerializeField] private Quest[] mainQuests;

    public Quest[] MainQuests
    {
        get => mainQuests;
    }

    [ContextMenu("Reset quests")]
    public void ResetQuests()
    {
        foreach(Quest q in mainQuests)
        {
            q.QuestState = QuestSate.Inactive;
            q.currentStep = 0;
        }
    }
}
