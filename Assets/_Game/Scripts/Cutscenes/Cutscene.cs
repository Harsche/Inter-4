using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Cinemachine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private bool bindPlayer;
    [SerializeField] private bool bindDialogCanvas;
    [SerializeField] private TimelineAsset[] possibleCutscenes;
    public PlayableDirector playableDirector { get; private set; }
    private TrackAsset[] cutsceneTracks;
    private TimelineAsset cutscene;
    static string PlayerReference = "Player";
    static string DialogCanvasReference = "DialogCanvas";

    private void Awake()
    {
        if (Globals.CutsceneManager.WasPlayed(gameObject.name)) Destroy(gameObject);

        playableDirector = GetComponent<PlayableDirector>();
        cutscene = playableDirector.playableAsset as TimelineAsset;
        cutsceneTracks = (TrackAsset[])cutscene.GetOutputTracks();
    }

    private void Start()
    {
        BindTimelineTracks();
    }

    public void SetCurrentCutscene()
    {
        Globals.CutsceneManager.SetCutscene(this);
    }

    public void SetCutscenePlayed()
    {
        Globals.CutsceneManager.SetCutscenePlayed(gameObject.name);
    }

    public void BindTimelineTracks()
    {
        if (bindPlayer) BindOrUnbindPlayer(true);
        if (!bindDialogCanvas) return;
        foreach (TrackAsset track in cutsceneTracks)
        {
            if (!(track.name == DialogCanvasReference)) continue;
            playableDirector.SetGenericBinding(track, Globals.DialogCanvas);
            break;
        }
    }

    public void BindOrUnbindPlayer(bool bind)
    {
        foreach (TrackAsset track in cutsceneTracks)
        {
            BindIfIsPlayer(track, bind);
        }
    }

    public void BindIfIsPlayer(TrackAsset track, bool bind)
    {
        if (!(track.name == PlayerReference)) return;
        if (!bind)
        {
            playableDirector.SetGenericBinding(track, null);
            return;
        }
        playableDirector.SetGenericBinding(track, Globals.Player.GetComponent<Animator>());
    }

    public void PlayerVCamOnOrOff(bool set)
    {
        Globals.PlayerVirtualCamera.SetActive(set);
    }

    public void PlayPossibleCutscene(int index)
    {
        playableDirector.playableAsset = possibleCutscenes[index];
        playableDirector.Play();
    }


    public void StartDialog(string inkKnot)
    {
        Globals.DialogManager.JumpTo(inkKnot);
        Globals.DialogManager.OpenDialog();
    }

    public void SetStory(TextAsset storyJson)
    {
        Globals.DialogManager.SetStory(storyJson);
    }

    public void TurnObjectOn(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void TurnObjectOff(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void SetCameraPriority(int priority)
    {
        Globals.PlayerVirtualCamera.GetComponent<CinemachineVirtualCamera>().Priority = priority;
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
