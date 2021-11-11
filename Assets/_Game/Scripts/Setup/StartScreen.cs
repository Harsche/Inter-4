using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void NewGameButton()
    {
        SaveManager.DeleteSave();
        SaveManager.NewSaveFile();
    }

    public void LoadGameButton()
    {
        SaveManager.LoadGame();
        if(SaveManager.saveFile != null)
            SceneManager.LoadScene("Load");
    }
}
