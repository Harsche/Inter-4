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

    private IEnumerator FadeOut(string sceneName, Vector2 newPosition)
    {
        fadeCanvas.SetActive(true);
        Globals.Player.GetComponent<Rigidbody2D>().simulated = false;
        Globals.CutsceneManager.PauseTimeline();

        yield return fadeImage.DOFade(1, fadeDuration).WaitForCompletion();
        SceneManager.LoadScene(sceneName);
        while(!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            yield return null;
        }

        Vector2 oldPosition = Globals.Player.transform.position;
        Globals.Player.transform.position = newPosition;
        virtualCamera.OnTargetObjectWarped(virtualCamera.m_Follow, newPosition-oldPosition);

        Globals.Player.GetComponent<Rigidbody2D>().simulated = true;
        Globals.CutsceneManager.ResumeTimeline();
        yield return fadeImage.DOFade(0, fadeDuration).WaitForCompletion();

        fadeCanvas.SetActive(false);
    }
}
