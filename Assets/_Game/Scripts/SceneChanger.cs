using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private float fadeDuration;
    [SerializeField] private Image fadeImage;
    private CinemachineVirtualCamera virtualCamera;
    private GameObject fadeCanvas;

    private void Start()
    {
        virtualCamera = Globals.PlayerVirtualCamera.GetComponent<CinemachineVirtualCamera>();
        fadeCanvas = transform.GetChild(0).gameObject;
        fadeCanvas.SetActive(false);
    }

    public void ChangeScene(string sceneName, Vector2 newPosition)
    {
        StartCoroutine(FadeOut(sceneName, newPosition));
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeOut(string sceneName, Vector2 newPosition)
    {
        fadeCanvas.SetActive(true);
        Globals.Player.GetComponent<Rigidbody2D>().simulated = false;
        Globals.CutsceneManager.PauseTimeline();
        Tween fade = fadeImage.DOFade(1, fadeDuration);
        fade.SetLink(gameObject);
        yield return fade.WaitForCompletion();

        Debug.Log("SAVED");
        Vector2 oldPosition = Globals.Player.transform.position;
        Globals.Player.transform.position = newPosition;
        virtualCamera.OnTargetObjectWarped(virtualCamera.m_Follow, newPosition - oldPosition);

        SceneManager.LoadScene(sceneName);
        while (!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            yield return null;
        }

        SaveManager.SaveAllData?.Invoke();
        SaveManager.SaveGame();

        Globals.Player.GetComponent<Rigidbody2D>().simulated = true;
        Globals.CutsceneManager.ResumeTimeline();
        fade = fadeImage.DOFade(0, fadeDuration);
        yield return fade.WaitForCompletion();

        fadeCanvas.SetActive(false);
    }

    private IEnumerator FadeOut(string sceneName)
    {
        fadeCanvas.SetActive(true);
        Globals.Player.GetComponent<Rigidbody2D>().simulated = false;
        Globals.CutsceneManager.PauseTimeline();
        Tween fade = fadeImage.DOFade(1, fadeDuration);
        fade.SetLink(gameObject);
        yield return fade.WaitForCompletion();
        Vector3 position = Globals.Player.transform.position;
        Debug.Log("SAVED");
        SceneManager.LoadScene(sceneName);
        while (!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            yield return null;
        }

        SaveManager.SaveAllData?.Invoke();
        SaveManager.SaveGame();

        Globals.Player.GetComponent<Rigidbody2D>().simulated = true;
        Globals.CutsceneManager.ResumeTimeline();
        fade = fadeImage.DOFade(0, fadeDuration);
        yield return fade.WaitForCompletion();

        fadeCanvas.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }
}
