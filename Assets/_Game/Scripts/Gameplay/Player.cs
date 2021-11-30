using UnityEngine;
using UnityEngine.SceneManagement;
using CleverCrow.Fluid.UniqueIds;
using System.Collections;

public class Player : MonoBehaviour
{
    public static AnimationControl animationControl { get; private set; }
    public static PlayerData playerData { get; private set; }
    private static string myGuid;
    private bool wasDataNull;
    private string lastScene;
    private Vector2 lastPosition;

    private void Awake()
    {
        animationControl = GetComponent<AnimationControl>();
        SaveManager.SaveAllData += SavePlayerData;
        myGuid = GetComponent<UniqueId>().Id;
        playerData = SaveManager.GetData<PlayerData>(myGuid);
        if (playerData != null)
        {
            wasDataNull = false;
            return;
        }
        playerData = new PlayerData();
        wasDataNull = true;
        lastScene = playerData.scene;
        lastPosition = playerData.position;
    }

    private void TestScene(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(WaitToTestScene(scene));   
    }

    private void OnDestroy() {
        SceneManager.sceneLoaded -= TestScene;
    }

    private void Start()
    {
        if (!wasDataNull)
        {
            Globals.PlayerVirtualCamera.SetActive(true);
            Debug.Log("ATIVOU");
            LoadSceneReady.SceneName = playerData.scene;
            transform.position = playerData.position;
        }
        SceneManager.sceneLoaded += TestScene;
    }

    public static void ChangeDayTime(DayTime time)
    {
        playerData.dayTime = time;
    }

    private void SavePlayerData()
    {
        playerData.scene = lastScene;
        playerData.position = lastPosition;
        SaveManager.SaveData(myGuid, playerData);
    }

    private IEnumerator WaitToTestScene(Scene scene)
    {
        yield return new WaitUntil(() => scene.isLoaded);
        if(scene.name != "Start" && scene.name != "Load")
        {
            lastScene = scene.name;
            lastPosition = transform.position;
        }
    }
}

public class PlayerData : ObjectData
{
    public string scene;
    public Vector2 position;
    public DayTime dayTime;
}
