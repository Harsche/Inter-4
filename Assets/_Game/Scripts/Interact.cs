using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject dialogCanvas;
    private Character character;

    private void Start()
    {
        character = GetComponent<Character>();
    }

    public void Interaction()
    {
        /*
        foreach(Quest quest in Globals.Player.GetComponent<QuestSystem>().quests)
        {
            switch(quest.step)
            {
                case QuestStep.Speak:
                if()
                break;
            }
        }
        */
    }
}
