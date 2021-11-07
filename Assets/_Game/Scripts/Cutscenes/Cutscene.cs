using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private bool bindPlayer;
    [SerializeField] private bool bindDialogCanvas;
    [SerializeField] private TimelineAsset[] possibleCutscenes;
    public PlayableDirector playableDirector { get; private set; }
    public bool isPlaying { get; private set; }
    private TrackAsset[] cutsceneTracks;
    private TimelineAsset cutscene;
    static string PlayerReference = "Player";
    static string DialogCanvasReference = "DialogCanvas";

    private void Awake()
    {
        if (Globals.CutsceneManager.WasPlayed(gameObject.name)) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        playableDirector = GetComponent<PlayableDirector>();
        if(playableDirector.playOnAwake)
        {
            SetCurrentCutscene();
            isPlaying = true;
        }
        cutscene = playableDirector.playableAsset as TimelineAsset;
        cutsceneTracks = (TrackAsset[])cutscene.GetOutputTracks();

        playableDirector.played += (director) => { isPlaying = true; };
        playableDirector.stopped += (director) => { isPlaying = false; };
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
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
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
        cutsceneTracks = (TrackAsset[])possibleCutscenes[index].GetOutputTracks();
        playableDirector.Play();
    }


    public void StartDialog(string inkKnot)
    {
        Globals.DialogManager.JumpTo(inkKnot);
        Globals.DialogManager.OpenDialog();
    }

    public void OpenDialog()
    {
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

    public void PauseTimeline()
    {
        Globals.CutsceneManager.PauseTimeline();
    }

    public void ResumeTimeline()
    {
        Globals.CutsceneManager.ResumeTimeline();
    }
}
