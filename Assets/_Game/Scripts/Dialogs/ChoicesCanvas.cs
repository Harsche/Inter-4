using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChoicesCanvas : MonoBehaviour
{
    [SerializeField] private GameObject choicePanel;
    private Button button1;
    private Button button2;
    private Text text1;
    private Text text2;
    Color normalColor;

    public void OnChoiceMade(int index)
    {
        choicePanel.SetActive(true);
        StartCoroutine(DisableChoices(index));
    }

    public void DisplayChoices(string[] choices)
    {
        choicePanel.SetActive(false);
        text1.text = choices[0];
        text2.text = choices[1];
        button1.interactable = true;
        button2.interactable = true;

        gameObject.SetActive(true);
    }

    public void Setup()
    {
        button1 = transform.GetChild(0).gameObject.GetComponent<Button>();
        button2= transform.GetChild(1).gameObject.GetComponent<Button>();
        text1 = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        text2= transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
        normalColor = button1.colors.normalColor;

    }

    IEnumerator DisableChoices(int index)
    {
        yield return new WaitForSeconds(0.25f);
        Globals.DialogManager.MakeChoice(index);
        gameObject.SetActive(false);
    }
}
