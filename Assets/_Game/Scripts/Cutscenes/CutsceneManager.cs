using UnityEngine.Playables;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private CutsceneData cutsceneData;
    public Cutscene currentCutscene { get; private set; }

    public bool WasPlayed(string cutsceneName)
    {
        int cutsceneNum = int.Parse(cutsceneName.Split('_')[1]);
        if (!(cutsceneData.states[cutsceneNum] == CutsceneState.Played)) return false;

        return true;
    }

    public void ChooseCutscene(int choiceIndex)
    {
        currentCutscene.PlayPossibleCutscene(choiceIndex);
    }

    public void SetCutscenePlayed(string cutsceneName)
    {
        int cutsceneNum = int.Parse(cutsceneName.Split('_')[1]);
        cutsceneData.states[cutsceneNum] = CutsceneState.Played;
    }

    public void SetCutscene(Cutscene cutscene)
    {
        currentCutscene = cutscene;
    }

    public void PauseTimeline()
    {
        if (currentCutscene.isPlaying) currentCutscene.playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }

    public void ResumeTimeline()
    {
        if(currentCutscene.isPlaying) currentCutscene.playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
}
