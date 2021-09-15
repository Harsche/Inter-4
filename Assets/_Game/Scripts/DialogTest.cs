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

    void Awake()
    {
        story = new Story(dialogJson.text);
    }

    public void LoadStory()
    {
        if (story.canContinue)
        {
            string[] separator = { ": " };
            charLine.Clear();
            charName.Clear();

            string[] newLine = story.Continue().Split(separator, 2, System.StringSplitOptions.None);
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

}
