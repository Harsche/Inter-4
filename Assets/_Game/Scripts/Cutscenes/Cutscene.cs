using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Globalization;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private bool storyCutscene;
    [SerializeField] private bool bindPlayer;
    [SerializeField] private bool bindDialogCanvas;
    [SerializeField] private TimelineAsset[] possibleCutscenes;
    [SerializeField] private CharacterInformation[] characterInformation;
    [SerializeField] private string[] deleteCharactersWithName;
    [SerializeField] private GameObject[] disableGameObjects;
    public PlayableDirector playableDirector { get; private set; }
    public bool isPlaying { get; private set; }
    private TrackAsset[] cutsceneTracks;
    private TimelineAsset cutscene;
    static string PlayerReference = "Player";
    static string DialogCanvasReference = "DialogCanvas";
    private float cutsceneNum;

    private void Awake()
    {
        if (storyCutscene)
        {
            if (Globals.CutsceneManager.WasPlayedOrCantPlay(gameObject.name))
            {
                Destroy(gameObject);
                return;
            }
            cutsceneNum = float.Parse(name.Substring(9), CultureInfo.InvariantCulture);
        }
        CutsceneManager.OnCallTriggerCutscene += PlayCutsceneIfTriggered;

        playableDirector = GetComponent<PlayableDirector>();

        cutscene = playableDirector.playableAsset as TimelineAsset;
        cutsceneTracks = (TrackAsset[])cutscene.GetOutputTracks();

        playableDirector.played += (director) => { isPlaying = true; DontDestroyOnLoad(gameObject); };
        playableDirector.stopped += (director) => { isPlaying = false; };
    }

    private void Start()
    {
        if (playableDirector.playOnAwake)
        {
            SetCurrentCutscene();
            isPlaying = true;
        }
        transform.SetParent(null);
        BindTimelineTracks();
        DeleteCharactersWithName();
        DisableObjects();
    }

    private void OnDestroy() {
        CutsceneManager.OnCallTriggerCutscene -= PlayCutsceneIfTriggered;

    }

    private void DisableObjects()
    {
        if(disableGameObjects == null)
            return;
        if(disableGameObjects.Length <= 0)
            return;
        foreach (GameObject obj in disableGameObjects)
        {
            obj.SetActive(false);
        }
    }
    

    public void PlayCutsceneIfTriggered(float cutsceneNum)
    {
        if (cutsceneNum == this.cutsceneNum)
            playableDirector.Play();
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

    public void DeleteCharactersWithName()
    {
        if (deleteCharactersWithName == null)
            return;
        GameObject[] currentCharacters = CharacterManager.Instance.currentCharacters.ToArray();
        foreach (GameObject character in currentCharacters)
            Destroy(character);
    }

    public void BindOrUnbindTracks(string trackName, bool bind, GameObject obj)
    {
        foreach (TrackAsset track in cutsceneTracks)
        {
            if (track.name != trackName)
                continue;
            if (bind)
            {
                playableDirector.SetGenericBinding(track, obj);
                continue;
            }
            playableDirector.SetGenericBinding(track, null);
        }
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

    public void SetCharactersPlaces()
    {
        if (characterInformation.Length > 0)
            CharacterManager.Instance.PlaceCharacters(characterInformation);
    }

    public void PlayPossibleCutscene(int index)
    {
        playableDirector.playableAsset = possibleCutscenes[index];
        cutsceneTracks = (TrackAsset[])possibleCutscenes[index].GetOutputTracks();
        playableDirector.Play();
    }

    public void GoToCreditsScreen()
    {
        foreach (GameObject obj in Globals.Instance.dontDestroy)
        {
            Destroy(obj);
        }
        SceneManager.LoadScene("Credits");
    }

    public void StartDialog(string inkKnot)
    {
        if (DialogManager.DialogOpened)
            return;
        inkKnot = inkKnot.Replace(' ', '_');
        Globals.DialogManager.OpenDialog();
        Globals.DialogManager.JumpTo(inkKnot);
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

    public void LoadScene(string sceneName)
    {
        Globals.SceneChanger.LoadScene(sceneName);
    }
}
