using UnityEngine;
using UnityEngine.Playables;

public class Cutscene : MonoBehaviour
{
    void Start()
    {
        Globals.CutsceneManager.SetDirector(GetComponent<PlayableDirector>());
    }
}
