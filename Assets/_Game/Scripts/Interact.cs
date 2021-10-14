using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private GameObject dialogCanvas;

    private void Start()
    {
        dialogCanvas = Globals.DialogCanvas;
    }

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
        Globals.DialogCanvas.SetActive(true);
    }

    public void SetObjectActive(GameObject obj)
    {
        obj.SetActive(true);
    }
}
