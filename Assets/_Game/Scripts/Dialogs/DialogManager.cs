using System.Text;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using Lean.Touch;
using System;
using System.Linq;
using CleverCrow.Fluid.UniqueIds;

public class DialogManager : MonoBehaviour
{
    public static int GameDay = 1;
    public static GameObject TalkingNPC;
    [SerializeField] private TextAsset dialogJson;
    [SerializeField] private Text dialogText;
    [SerializeField] private Text nameText;
    [SerializeField] private ChoicesCanvas choicesCanvas;
    private Canvas myCanvas;
    private float enableTime;
    private Movement playerMovement;
    private StringBuilder charName = new StringBuilder();
    private StringBuilder charLine = new StringBuilder();
    private Story story;
    private static StoryData storyData;
    private static string myGuid;
    private bool displayingChoices;

    private void Awake()
    {
        SaveManager.SaveAllData += SaveStoryData;
        myGuid = GetComponent<UniqueId>().Id;
        choicesCanvas.Setup();
        myCanvas = GetComponent<Canvas>();
        storyData = SaveManager.GetData<StoryData>(myGuid);
        if (storyData == null)
        {
            storyData = new StoryData();
            return;
        }
        SetStory(dialogJson);
        //ContinueStory();
    }

    private void Start()
    {
        playerMovement = Globals.Player.GetComponent<Movement>();
    }

    public void SetStory(TextAsset storyJson)
    {
        if (story != null && story.state != null)
        {
            SaveStoryState();
        }

        story = new Story(storyJson.text);
        BindMethods();

        if (story != null && !String.IsNullOrEmpty(storyData.jsonStory))
        {
            LoadStoryState();
        }
    }

    private void SaveStoryData()
    {
        SaveManager.SaveData(myGuid, storyData);
    }

    public void SaveStoryState()
    {
        storyData.jsonStory = story.state.ToJson();
    }

    public void LoadStoryState()
    {
        story.state.LoadJson(storyData.jsonStory);
    }

    public void ContinueStory()
    {
        if (displayingChoices) return;

        string[] separator = { ": " };
        charLine.Clear();
        charName.Clear();

        if (story.canContinue)
        {
            story.Continue();
            while (!HasContent(story.currentText) && story.canContinue)
            {
                story.Continue();
            }

            if (HasContent(story.currentText))
            {
                string[] newLine = story.currentText.Split(separator, 2, System.StringSplitOptions.None);
                charName.Append(newLine[0]);
                charLine.Append("    ");
                charLine.Append(newLine[1]);


                nameText.text = charName.ToString();
                dialogText.text = charLine.ToString();
            }
            else
            {
                CloseDialog();
            }

        }
        else if (story.currentChoices.Count > 0)
        {
            displayingChoices = true;
            string[] choices = story.currentChoices.Select(text => text.text).ToArray();
            choicesCanvas.DisplayChoices(choices);
        }
        else
        {
            CloseDialog();
        }
    }

    public void MakeChoice(int index)
    {
        story.ChooseChoiceIndex(index);
        displayingChoices = false;
        ContinueStory();
    }

    private bool HasContent(string line)
    {
        if (!String.IsNullOrEmpty(line) && !String.IsNullOrWhiteSpace(line))
        {
            return true;
        }
        else return false;
    }

    public void ContinueStoryOnTap(LeanFinger finger)
    {
        if (Time.time - finger.Age > enableTime)
        {
            ContinueStory();
        }
    }

    public void JumpTo(string inkKnot)
    {
        story.ChoosePathString(inkKnot);
        ContinueStory();
    }

    private void BindMethods()
    {
        story.BindExternalFunction("PauseTimeline", () => { Globals.CutsceneManager.PauseTimeline(); });
        story.BindExternalFunction("ResumeTimeline", () => { Globals.CutsceneManager.ResumeTimeline(); });
        story.BindExternalFunction("newQuest", (string questName) => { Globals.QuestManager.StartNewQuest(questName); });
        story.BindExternalFunction("Debug", (string value) => { Debug.Log(value); });
        story.BindExternalFunction("ChooseCutscene", (int choiceIndex) => { Globals.CutsceneManager.ChooseCutscene(choiceIndex); });
        story.BindExternalFunction("PlayCutscene", (int cutsceneNum) => { CutsceneManager.TriggerCutscene(cutsceneNum); });
        story.BindExternalFunction("CloseDialog", () => { CloseDialog(); });
        story.BindExternalFunction("ChangeGameDay", (int day) => { Debug.Log("CHANGED DAY" + day); });
    }

    public void OpenDialog()
    {
        enableTime = Time.time;
        for (int i = 0; i < transform.childCount - 2; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        myCanvas.enabled = true;
        playerMovement.canMove = false;
    }

    public void CloseDialog()
    {
        SaveStoryState();
        for (int i = 0; i < transform.childCount - 2; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        myCanvas.enabled = false;
        playerMovement.canMove = true;

        if (TalkingNPC != null)
        {
            TalkingNPC.GetComponent<NPC_Movement>().enabled = true;
            TalkingNPC = null;
        }
    }
}

public class StoryData : ObjectData
{
    public string jsonStory;
}
