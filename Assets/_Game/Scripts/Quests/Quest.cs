using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest 
{
    public string questName { get; private set; }
    public string goal { get; private set; }

    public Quest(string questName, string goal)
    {
        this.questName = questName;
        this.goal = goal;
    }

    public void SetQuestGoal(string newGoal)
    {
        goal = newGoal;
    }

    public void CompleteQuest()
    {
        
    }
}