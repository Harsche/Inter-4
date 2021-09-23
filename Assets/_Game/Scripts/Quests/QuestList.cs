using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/QuestList")]
public class QuestList : ScriptableObject
{
    [SerializeField] private Quest[] mainQuests;

    public Quest[] MainQuests
    {
        get => mainQuests;
    }
}
