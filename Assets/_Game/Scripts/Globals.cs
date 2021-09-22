using UnityEngine;

public class Globals : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private GameObject newQuestCanvas;
    [SerializeField] private CutsceneManager cutsceneManager;

    public static GameObject Player;
    public static GameObject DialogCanvas;
    public static GameObject NewQuestCanvas;
    public static CutsceneManager CutsceneManager;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Player = player;
        DialogCanvas = dialogCanvas;
        CutsceneManager = cutsceneManager;
    }

}
