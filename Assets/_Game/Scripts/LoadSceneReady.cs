using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneReady : MonoBehaviour
{
    [SerializeField] private string sceneName;

    void Update()
    {
        if(SceneManager.GetActiveScene().isLoaded)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
