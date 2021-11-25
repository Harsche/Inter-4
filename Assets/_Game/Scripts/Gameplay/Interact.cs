using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] string myName;
    [SerializeField] TextAsset myStory;
    [SerializeField] bool isNPC;

    public void SetStory(TextAsset storyJson)
    {
        Globals.DialogManager.SetStory(storyJson);
    }

    public void SetDialog(string inkKnot)
    {
        Globals.DialogManager.JumpTo(inkKnot);
    }

    public void StartDialog(string inkKnot)
    {
        Globals.DialogManager.JumpTo(inkKnot);
        Globals.DialogManager.OpenDialog();
    }

    public void SetObjectActive(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void DoInteraction()
    {
        string storyKnot = Globals.QuestManager.GetQuestDialog(myName);
        //Globals.DialogManager.SetStory(myStory);
        Globals.DialogManager.OpenDialog();
        Globals.DialogManager.JumpTo(storyKnot);

        if(isNPC)
        {
            DialogManager.TalkingNPC = transform.parent.gameObject;
            transform.parent.gameObject.GetComponent<NPC_Movement>().enabled = false;
        }
    }
}
