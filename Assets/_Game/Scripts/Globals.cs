using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

public class Globals : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerVirtualCamera;
    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private GameObject newQuestCanvas;
    [SerializeField] private CutsceneManager cutsceneManager;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private DialogManager dialogManager;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private GameObject[] dontDestroy;
    

    public static GameObject Player;
    public static GameObject PlayerVirtualCamera;
    public static GameObject DialogCanvas;
    public static GameObject NewQuestCanvas;
    public static CutsceneManager CutsceneManager;
    public static SceneChanger SceneChanger;

    public static QuestManager QuestManager;
    public static DialogManager DialogManager;
    

    private void Awake()
    {
        //Global objects and references

        Application.targetFrameRate = 60;
        Player = player;
        PlayerVirtualCamera = playerVirtualCamera;
        DialogCanvas = dialogCanvas;
        CutsceneManager = cutsceneManager;
        NewQuestCanvas = newQuestCanvas;
        QuestManager = questManager;
        DialogManager = dialogManager;
        SceneChanger = sceneChanger;

        //Dont destroy objects on load

        foreach(GameObject go in dontDestroy)
        {
            DontDestroyOnLoad(go);
        }
    }

    #if UNITY_EDITOR
    [ContextMenu("Setup Scene")]
    public void SetupScene()
    {
        Scene activeScene = EditorSceneManager.GetActiveScene();
        GameObject[] allGameObjects = activeScene.GetRootGameObjects();

        newQuestCanvas = allGameObjects.First(go => go.name == "Canvas_NewQuest");
        dialogCanvas = allGameObjects.First(go => go.name == "Canvas_Dialog");

        player = GameObject.FindGameObjectWithTag("Player");
        playerVirtualCamera = GameObject.Find("Virtual Camera Player");
        dialogManager = dialogCanvas.GetComponent<DialogManager>();

        dontDestroy = new GameObject[6];
        dontDestroy[0] = player;
        dontDestroy[1] = gameObject;
        dontDestroy[2] = playerVirtualCamera;
        dontDestroy[3] = dialogCanvas;
        dontDestroy[4] = newQuestCanvas;
        dontDestroy[5] = GameObject.FindGameObjectWithTag("MainCamera");
    }
    #endif

}
