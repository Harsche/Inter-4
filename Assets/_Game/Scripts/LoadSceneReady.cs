using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneReady : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public static string SceneName;
    private bool load;

    private void Awake()
    {
        load = true;
        SceneName = sceneName;
    }

    void Update()
    {
        if (load && SceneManager.GetActiveScene().isLoaded)
        {
            Globals.SceneChanger.ChangeScene(SceneName);
            load = false;
        }
    }
}
