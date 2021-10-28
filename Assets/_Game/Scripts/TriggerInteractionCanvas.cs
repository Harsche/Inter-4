using System.Collections;
using UnityEngine;
using DG.Tweening;

public class TriggerInteractionCanvas : MonoBehaviour
{
    [SerializeField] private float scaleDuration;
    private Transform interactionTransform;
    Canvas interactionCanvas;

    private void Awake()
    {
        interactionTransform = transform.GetChild(0).GetChild(0);
        interactionTransform.localScale = Vector3.zero;
        interactionCanvas = transform.GetChild(0).gameObject.GetComponent<Canvas>();
        StartCoroutine(DisableCanvas());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionCanvas.enabled = true;
            interactionTransform.gameObject.SetActive(true);
            interactionTransform.localScale = Vector3.zero;
            interactionTransform.DOScale(1.0f, scaleDuration);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionTransform.DOScale(0.0f, scaleDuration).OnComplete(() =>  
            {
                interactionCanvas.enabled = false;
                interactionTransform.gameObject.SetActive(false);
            });
        }
    }

    IEnumerator DisableCanvas()
    {
        yield return new WaitForEndOfFrame();
        interactionCanvas.enabled = false;
        interactionTransform.gameObject.SetActive(false);
    }
}
