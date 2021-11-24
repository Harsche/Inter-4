using UnityEngine;
using UnityEngine.SceneManagement;
using CleverCrow.Fluid.UniqueIds;

public class Player : MonoBehaviour
{
    public static AnimationControl animationControl { get; private set; }
    public static PlayerData playerData { get; private set; }
    private static string myGuid;
    private bool wasDataNull;

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
    }

    public static void ChangeDayTime(DayTime time)
    {
        playerData.dayTime = time;
    }

    private void SavePlayerData()
    {
        playerData.scene = SceneManager.GetActiveScene().name;
        playerData.position = transform.position;
        SaveManager.SaveData(myGuid, playerData);
    }
}

public class PlayerData : ObjectData
{
    public string scene;
    public Vector2 position;
    public DayTime dayTime;
}
