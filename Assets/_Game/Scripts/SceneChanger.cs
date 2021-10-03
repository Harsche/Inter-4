using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private float fadeDuration;
    [SerializeField] private Image fadeImage;
    private GameObject fadeCanvas;

    private void Start()
    {
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
        yield return fadeImage.DOFade(1, fadeDuration).WaitForCompletion();
        SceneManager.LoadScene(sceneName);
        Globals.Player.transform.position = newPosition;
        fadeImage.DOFade(0, fadeDuration).WaitForCompletion();
        fadeCanvas.SetActive(false);
    }
}
