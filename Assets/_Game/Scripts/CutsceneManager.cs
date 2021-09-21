using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector director { get; private set; }

    public void SetDirector(PlayableDirector pd)
    {
        director = pd;
    }

    public void StopCutscene()
    {
        director.Stop();
    }

    public void PauseTimeline()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }

    public void ResumeTimeline()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
}
