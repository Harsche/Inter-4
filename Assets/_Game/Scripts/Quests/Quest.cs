using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Quest", fileName = "Quest_New Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    public int currentStep;
    public QuestSate questState;
    public QuestStep[] questSteps;

    public void NextStep()
    {
        currentStep++;
    }
}

[System.Serializable]
public enum QuestSate
{
    Inactive,
    Active,
    Completed
}

[System.Serializable]
public enum QuestType
{
    TalkTo,
    NumberedTask

}

[System.Serializable]
public class QuestStep
{
    public int id;
    public string goal;
    public QuestType questType;
    public string goalName;
    public int currentNum;
    public int goalNum;
}

