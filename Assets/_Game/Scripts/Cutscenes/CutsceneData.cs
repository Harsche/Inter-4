using UnityEngine.Timeline;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Cutscene Data")]
public class CutsceneData : ScriptableObject
{
    public CutsceneState[] states;

    [ContextMenu("Set all playable")]
    public void SetAllPlayable()
    {
        for(int i = 0; i < states.Length; i++)
        {
            states[i] = CutsceneState.CanPlay;
        }
    }

    [ContextMenu("Set all unplayable")]
    public void SetAllUnlayable()
    {
        for(int i = 0; i < states.Length; i++)
        {
            states[i] = CutsceneState.CanNotPlay;
        }
    }

    [ContextMenu("Set all played")]
    public void SetAllPlayed()
    {
        for(int i = 0; i < states.Length; i++)
        {
            states[i] = CutsceneState.Played;
        }
    }
}

public enum CutsceneState
{
    CanPlay,
    CanNotPlay,
    Played
}