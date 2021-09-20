using System.Text;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class DialogTest : MonoBehaviour
{
    [SerializeField] TextAsset dialogJson;
    [SerializeField] Text dialogText;
    [SerializeField] Text nameText;
    private StringBuilder charName = new StringBuilder();
    private StringBuilder charLine = new StringBuilder();
    private Story story;

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

    public void ContinueStory(bool next)
    {
        string[] separator = { ": " };
        charLine.Clear();
        charName.Clear();

        if (story.canContinue)
        {
            story.Continue();

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

}
