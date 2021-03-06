using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject confirmNewGame;
    [SerializeField] private GameObject[] objectsToTurnOff;
    [SerializeField] private CutsceneSOData cutsceneSOData;
    [SerializeField] private CutsceneSOData cutsceneSODataNewGame;
    [SerializeField] private QuestList questList;
    [SerializeField] private CharactersSOData charactersSOData;

    private bool hasSave;

    private void Awake()
    {
        hasSave = CheckIfThereIsSaveFile();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if(Application.targetFrameRate != 60)
            Application.targetFrameRate = 60;
    }

    public void NewGameButton()
    {
        if (hasSave)
        {
            ActivateOrDeactivate(false);
            confirmNewGame.SetActive(true);
            return;
        }
        StartNewGame();
    }

    public void LoadGameButton()
    {
        SaveManager.LoadGame();
        if (SaveManager.saveFile != null)
            SceneManager.LoadScene("Load");
    }

    private bool CheckIfThereIsSaveFile()
    {
        return File.Exists(SaveManager.savePath);
    }

    public void StartNewGame()
    {
        SaveManager.DeleteSave();
        SaveManager.NewSaveFile();
        cutsceneSOData.SetAllPlayable();
        questList.ResetQuests();
        charactersSOData.ResetCharacters();
        cutsceneSOData.statuses = cutsceneSODataNewGame.statuses;
        if (SaveManager.saveFile != null)
            SceneManager.LoadScene("Load");
        if(CheckIfThereIsSaveFile())
            File.Delete(SaveManager.savePath);
    }

    public void ActivateOrDeactivate(bool active)
    {
        foreach (GameObject obj in objectsToTurnOff)
            obj.SetActive(active);
    }
}
