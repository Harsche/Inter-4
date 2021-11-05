using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class CutscenePlayer : MonoBehaviour
{
    private PlayableDirector myPlayableDirector;
    public static CutscenePlayer Instance;

    private void Awake()
    {
        Instance = this;
        myPlayableDirector = GetComponent<PlayableDirector>();
    }

    public void PlayCutscene(string cutsceneName)
    {
        TimelineAsset cutscene = Resources.Load<TimelineAsset>(cutsceneName);
        myPlayableDirector.Play(cutscene);
    }
}