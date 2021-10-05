using System.Text;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using Lean.Touch;

public class DialogManager : MonoBehaviour
{
    [SerializeField] TextAsset dialogJson;
    [SerializeField] Text dialogText;
    [SerializeField] Text nameText;
    private float enableTime;
    private Movement playerMovement;
    private StringBuilder charName = new StringBuilder();
    private StringBuilder charLine = new StringBuilder();
    private Story story;

    private void Awake()
    {
        playerMovement = Globals.Player.GetComponent<Movement>();
        SetStory(dialogJson);
        ContinueStory();
    }

    private void OnEnable()
    {
        enableTime = Time.time;
        playerMovement.canMove = false;
    }

    private void OnDisable()
    {
        playerMovement.canMove = true;
    }

    public void SetStory(TextAsset storyJson)
    {
        story = new Story(storyJson.text);
        BindMethods();
    }

    public void SaveStoryState()
    {

    }

    public void LoadStoryState()
    {

    }

    public void ContinueStory()
    {
        string[] separator = { ": " };
        charLine.Clear();
        charName.Clear();

        if (story.canContinue)
        {
            story.Continue();
            while ((story.currentText == "" || story.currentText == null) && story.canContinue)
            {
                story.Continue();
            }

            if (!(story.currentText == "" || story.currentText == null))
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
                gameObject.SetActive(false);
            }

        }
        else
        {

            gameObject.SetActive(false);
        }
    }

    public void ContinueStoryOnTap(LeanFinger finger)
    {
        if(Time.time - finger.Age > enableTime)
        {
            ContinueStory();
        }
    }

    public void JumpTo(string inkKnot)
    {
        story.ChoosePathString(inkKnot);
        ContinueStory();
    }

    public void BindMethods()
    {
        story.BindExternalFunction("pauseTimeline", () => { Globals.CutsceneManager.PauseTimeline(); });
        story.BindExternalFunction("resumeTimeline", () => { Globals.CutsceneManager.ResumeTimeline(); });
        story.BindExternalFunction("newQuest", (string questName) => { Globals.QuestManager.StartNewQuest(questName); });
    }

    public void OpenDialog()
    {
        gameObject.SetActive(true);
    }

    public void CloseDialog()
    {
        gameObject.SetActive(false);
    }

}
