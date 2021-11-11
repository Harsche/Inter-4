using UnityEngine;
using UnityEngine.SceneManagement;
using CleverCrow.Fluid.UniqueIds;

public class Player : MonoBehaviour
{
    private static PlayerData playerData;
    private static string myGuid;
    private bool wasDataNull;

    private void Awake()
    {
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
}
