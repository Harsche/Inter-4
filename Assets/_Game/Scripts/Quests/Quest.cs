using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Quest", fileName = "Quest_New Quest")]
public class Quest : ScriptableObject
{
    [SerializeField] private string questName;
    public int currentStep;
    [TextArea(3, 5)]
    [SerializeField] private string[] steps;
    public QuestSate QuestState;

    public void NextStep()
    {
        currentStep++;
    }

    public string QuestName
    {
        get => questName;
    }
}

public enum QuestSate
    {
        Inactive,
        Active,
        Completed
    }