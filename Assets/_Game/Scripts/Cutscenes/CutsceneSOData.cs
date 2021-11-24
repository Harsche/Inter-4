using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObjects/Cutscene Data")]
public class CutsceneSOData : ScriptableObject
{
    public CutsceneStatus[] statuses;

    [ContextMenu("Set all playable")]
    public void SetAllPlayable()
    {
        for(int i = 0; i < statuses.Length; i++)
        {
            statuses[i].state = CutsceneState.CanPlay;
        }
    }

    [ContextMenu("Set all unplayable")]
    public void SetAllUnlayable()
    {
        for(int i = 0; i < statuses.Length; i++)
        {
            statuses[i].state = CutsceneState.CanNotPlay;
        }
    }

    [ContextMenu("Set all played")]
    public void SetAllPlayed()
    {
        for(int i = 0; i < statuses.Length; i++)
        {
            statuses[i].state = CutsceneState.Played;
        }
    }
}

[System.Serializable]
public class CutsceneStatus
{
    public string cutsceneNumber;
    public CutsceneState state;
}

public enum CutsceneState
{
    CanPlay,
    CanNotPlay,
    Played
}