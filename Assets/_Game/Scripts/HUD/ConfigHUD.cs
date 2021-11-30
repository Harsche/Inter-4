using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigHUD : MonoBehaviour
{
    private const string startScene = "Start";

    public void MusicToggle()
    {

    }

    public void SoundToggle()
    {

    }

    public void ExitButton()
    {
        StartCoroutine(ExitGame());
    }

    private IEnumerator ExitGame()
    {
        Globals.SceneChanger.ChangeScene(startScene);
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == startScene);
        foreach (GameObject obj in Globals.Instance.dontDestroy)
        {
            Destroy(obj);
        }
        SaveManager.ResetSaveAllData();
    }

}
