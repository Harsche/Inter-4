using UnityEngine;

public class Globals : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private GameObject newQuestCanvas;
    [SerializeField] private CutsceneManager cutsceneManager;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private GameObject[] dontDestroy;
    

    public static GameObject Player;
    public static GameObject DialogCanvas;
    public static GameObject NewQuestCanvas;
    public static CutsceneManager CutsceneManager;
    public static SceneChanger SceneChanger;

    public static QuestManager QuestManager;
    

    private void Awake()
    {
        //Global objects and references

        Application.targetFrameRate = 60;
        Player = player;
        DialogCanvas = dialogCanvas;
        CutsceneManager = cutsceneManager;
        NewQuestCanvas = newQuestCanvas;
        QuestManager = questManager;
        SceneChanger = sceneChanger;

        //Dont destroy objects on load

        foreach(GameObject go in dontDestroy)
        {
            DontDestroyOnLoad(go);
        }
    }

}
