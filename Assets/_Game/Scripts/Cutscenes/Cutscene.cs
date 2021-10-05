using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private bool bindPlayer;
    [SerializeField] private bool bindDialogCanvas;
    private PlayableDirector playableDirector;
    private TimelineAsset cutscene;
    static string PlayerReference = "Player";
    static string DialogCanvasReference = "DialogCanvas";

    private void Awake()
    {
        if (Globals.CutsceneManager.WasPlayed(gameObject.name))
        {
            Destroy(gameObject);
        }

        playableDirector = GetComponent<PlayableDirector>();
        cutscene = playableDirector.playableAsset as TimelineAsset;
    }



    void Start()
    {
        Globals.CutsceneManager.SetDirector(playableDirector);
        BindTimelineTracks();
    }

    public void SetCutscenePlayed()
    {
        Globals.CutsceneManager.SetCutscenePlayed(gameObject.name);
    }

    public void BindTimelineTracks()
    {
        if (bindPlayer)
        {
            BindOrUnbindPlayer(1);
        }

        if (bindDialogCanvas)
        {
            foreach (TrackAsset track in cutscene.GetOutputTracks())
            {
                if (track.name == DialogCanvasReference)
                {
                    playableDirector.SetGenericBinding(track, Globals.DialogCanvas);
                    break;
                }
            }
        }
    }

    public void BindOrUnbindPlayer(int bind)
    {
        bool doBind = Convert.ToBoolean(bind);

        foreach (TrackAsset track in cutscene.GetOutputTracks())
        {
            if (track.name == PlayerReference)
            {
                if (doBind)
                {
                    playableDirector.SetGenericBinding(track, Globals.Player.GetComponent<Animator>());
                }
                else
                {
                    playableDirector.SetGenericBinding(track, null);
                }
            }
        }
    }

    public void StartDialog(string inkKnot)
    {
        Globals.DialogManager.JumpTo(inkKnot);
        Globals.DialogCanvas.SetActive(true);
    }


    public void PauseTimeline()
    {
        Globals.CutsceneManager.PauseTimeline();
    }

    public void ResumeTimeline()
    {
        Globals.CutsceneManager.ResumeTimeline();
    }
}
