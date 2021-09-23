using System.Text;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.Playables;

public class DialogTest : MonoBehaviour
{
    [SerializeField] TextAsset dialogJson;
    [SerializeField] Text dialogText;
    [SerializeField] Text nameText;
    private PlayableDirector playableDirector;
    private StringBuilder charName = new StringBuilder();
    private StringBuilder charLine = new StringBuilder();
    private Story story;

    private void Awake()
    {
        playableDirector = Globals.CutsceneManager.director;
        SetStory(dialogJson);
        BindMethods();
        ContinueStory();
    }

    private void OnEnable()
    {
        playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }

    private void OnDisable()
    {
        playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }

    public void SetStory(TextAsset storyJson)
    {
        story = new Story(storyJson.text);
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
            if(story.currentText == "" || story.currentText == null)
            {
                gameObject.SetActive(false);
                return;
            }

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

    public void JumpTo(string storyScene)
    {
        story.ChoosePathString(storyScene);
    }

    public void BindMethods()
    {
        story.BindExternalFunction("newQuest", (string questName) => { Globals.QuestManager.StartNewQuest(questName); });
        story.BindExternalFunction("playCutscene", () => { playableDirector.Stop(); });
    }

}
