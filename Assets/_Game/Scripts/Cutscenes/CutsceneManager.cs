using CleverCrow.Fluid.UniqueIds;
using UnityEngine.Playables;
using UnityEngine;
using System;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private CutsceneSOData cutsceneSOData;
    public static Action<int> OnCallTriggerCutscene;
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

    public static void TriggerCutscene(int cutsceneNum)
    {
        OnCallTriggerCutscene?.Invoke(cutsceneNum);
    }

    public bool WasPlayed(string cutsceneName)
    {
        int cutsceneNum = int.Parse(cutsceneName.Split('_')[1]);
        if (!(cutsceneSOData.states[cutsceneNum] == CutsceneState.Played)) return false;

        return true;
    }

    public void ChooseCutscene(int choiceIndex)
    {
        currentCutscene.PlayPossibleCutscene(choiceIndex);
    }

    public void SetCutscenePlayed(string cutsceneName)
    {
        int cutsceneNum = int.Parse(cutsceneName.Split('_')[1]);
        cutsceneSOData.states[cutsceneNum] = CutsceneState.Played;
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
}

public class CutsceneData : ObjectData
{
    public CutsceneSOData cutsceneSOData;
}
