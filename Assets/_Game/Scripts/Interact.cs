using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private GameObject dialogCanvas;
    private Character character;

    private void Start()
    {
        dialogCanvas = Globals.DialogCanvas;
        character = GetComponent<Character>();
    }

    public void SetStory(TextAsset storyJson)
    {
        Globals.DialogManager.SetStory(storyJson);
    }

    public void StartDialog(string inkKnot)
    {
        Globals.DialogManager.JumpTo(inkKnot);
        Globals.DialogCanvas.SetActive(true);
    }

    public void SetObjectActive(GameObject obj)
    {
        obj.SetActive(true);
    }
}
