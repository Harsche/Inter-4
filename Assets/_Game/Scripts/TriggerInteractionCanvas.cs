using System.Collections;
using UnityEngine;
using DG.Tweening;

public class TriggerInteractionCanvas : MonoBehaviour
{
    [SerializeField] private float scaleDuration;
    private Transform interactionTransform;
    private Canvas interactionCanvas;
    private Tween disable;
    private Tween enable;

    private void Awake()
    {
        interactionTransform = transform.GetChild(0).GetChild(0);
        interactionTransform.localScale = Vector3.zero;
        interactionCanvas = transform.GetChild(0).gameObject.GetComponent<Canvas>();
        StartCoroutine(DisableCanvasOnStart());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EnableInteraction();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DisableInteraction();
        }
    }

    public void EnableInteraction()
    {
        if(disable != null)
            disable.Kill();
        interactionCanvas.enabled = true;
        interactionTransform.gameObject.SetActive(true);
        interactionTransform.localScale = Vector3.zero;
        enable = interactionTransform.DOScale(1.0f, scaleDuration);
    }

    public void DisableInteraction()
    {
        if(enable != null)
            enable.Kill();
        disable = interactionTransform.DOScale(0.0f, scaleDuration).OnComplete(() =>
            {
                interactionCanvas.enabled = false;
                interactionTransform.gameObject.SetActive(false);
            });
    }

    IEnumerator DisableCanvasOnStart()
    {
        yield return new WaitForEndOfFrame();
        interactionCanvas.enabled = false;
        interactionTransform.gameObject.SetActive(false);
    }
}
