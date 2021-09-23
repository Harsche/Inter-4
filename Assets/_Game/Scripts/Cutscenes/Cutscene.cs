using UnityEngine;
using UnityEngine.Playables;

public class Cutscene : MonoBehaviour
{
    void Awake()
    {
        Globals.CutsceneManager.SetDirector(GetComponent<PlayableDirector>());
        if(Globals.CutsceneManager.WasPlayed(gameObject.name))
        {
            Destroy(gameObject);
        }
    }

    public void SetCutscenePlayed()
    {
        Globals.CutsceneManager.SetCutscenePlayed(gameObject.name);
    }
}
