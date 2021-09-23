using UnityEngine.Playables;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private CutsceneData cutsceneData;
    public PlayableDirector director { get; private set; }

    public bool WasPlayed(string cutsceneName)
    {
        
        int cutsceneNum = int.Parse(cutsceneName.Split('_')[1]);
        if(cutsceneData.states[cutsceneNum] == CutsceneState.Played)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetCutscenePlayed(string cutsceneName)
    {
        int cutsceneNum = int.Parse(cutsceneName.Split('_')[1]);
        cutsceneData.states[cutsceneNum] = CutsceneState.Played;
    }



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
