using CleverCrow.Fluid.UniqueIds;
using UnityEngine.Playables;
using UnityEngine;
using System;
using System.Linq;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private CutsceneSOData cutsceneSOData;
    public static Action<float> OnCallTriggerCutscene;
    public Cutscene currentCutscene { get; private set; }
    private CutsceneData cutsceneData;
    private string myGuid;

    private void Awake()
    {
        SaveManager.SaveAllData += SaveCutsceneData;
        myGuid = GetComponent<UniqueId>().Id;
        cutsceneData = SaveManager.GetData<CutsceneData>(myGuid);
        if (cutsceneData != null)
        {
            cutsceneSOData = cutsceneData.cutsceneSOData;
            return;
        }
        cutsceneData = new CutsceneData();
    }

    public static void TriggerCutscene(float cutsceneNum)
    {
        OnCallTriggerCutscene?.Invoke(cutsceneNum);
    }

    public bool WasPlayedOrCantPlay(string cutsceneName)
    {
        CutsceneStatus status = GetCutsceneStatus(cutsceneName);
        CutsceneState state = status.state;
        if (state == CutsceneState.Played || state == CutsceneState.CanNotPlay)
            return true;
        return false;
    }

    public void ChooseCutscene(int choiceIndex)
    {
        currentCutscene.PlayPossibleCutscene(choiceIndex);
    }

    public void SetCutscenePlayed(string cutsceneName)
    {
        CutsceneStatus status = GetCutsceneStatus(cutsceneName);
        status.state = CutsceneState.Played;
    }

    public void SetCutscenePlayable(string cutsceneNumber)
    {
        string cutsceneName = "Cutscene_" + cutsceneNumber;
        CutsceneStatus status = GetCutsceneStatus(cutsceneName);
        status.state = CutsceneState.CanPlay;
    }

    public void SetCutscene(Cutscene cutscene)
    {
        currentCutscene = cutscene;
    }

    public void PauseTimeline()
    {
        if (currentCutscene != null && currentCutscene.isPlaying)
            currentCutscene.playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }

    public void ResumeTimeline()
    {
        if (currentCutscene != null && currentCutscene.isPlaying)
            currentCutscene.playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }

    private void SaveCutsceneData()
    {
        cutsceneData.cutsceneSOData = cutsceneSOData;
        SaveManager.SaveData(myGuid, cutsceneData);
    }

    private CutsceneStatus GetCutsceneStatus(string cutsceneName)
    {
        string cutsceneNum = cutsceneName.Split('_')[1];
        CutsceneStatus status = cutsceneSOData.statuses.First(status => status.cutsceneNumber == cutsceneNum);
        return status;
    }
}

public class CutsceneData : ObjectData
{
    public CutsceneSOData cutsceneSOData;
    
}
