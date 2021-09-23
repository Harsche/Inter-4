using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class BindTimelineTracks : MonoBehaviour
{
    [SerializeField] private TimelineAsset cutscene;
    static string playerReference = "Player";
    static string dialogCanvasReference = "DialogCanvas";

    private PlayableDirector playableDirector;
    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();

        foreach(TrackAsset track in cutscene.GetOutputTracks())
        {
            if(track.name == playerReference)
            {
                playableDirector.SetGenericBinding(track, Globals.Player.GetComponent<Animator>());
                continue;
            }
            else if(track.name == dialogCanvasReference)
            {
                playableDirector.SetGenericBinding(track, Globals.DialogCanvas);
            }
        }
    }
}
