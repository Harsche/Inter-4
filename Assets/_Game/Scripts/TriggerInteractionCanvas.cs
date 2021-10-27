using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TriggerInteractionCanvas : MonoBehaviour
{
    [SerializeField] private float scaleDuration;
    private Transform interactionTransform;

    private void Awake()
    {
        interactionTransform = transform.GetChild(0).GetChild(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("test");
            interactionTransform.parent.gameObject.SetActive(true);
            interactionTransform.localScale = Vector3.zero;
            interactionTransform.DOScale(1.0f, scaleDuration);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionTransform.DOScale(0.0f, scaleDuration).OnComplete(() => interactionTransform.parent.gameObject.SetActive(false));
        }
    }
}
