using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using Lean.Touch;

public class ChopTask : MonoBehaviour
{
    [SerializeField] private WoodenLog woodenLog;
    [SerializeField] private Slider slider;
    [SerializeField] float speed = 2f;
    private bool taskStarted;
    private const string axeDown = "Luiz_Cortando_Lenha";
    private const float chopTime = 2 / 3f;
    private int chopCount;
    private Canvas myCanvas;
    private Tween chop;

    private void Awake()
    {
        myCanvas = GetComponent<Canvas>();
        StartCoroutine(DisableSelf());
    }

    public void StartTask()
    {
        myCanvas.enabled = true;
        StartSlider();
        taskStarted = true;
    }

    public void TryToChop(LeanFinger finger)
    {
        if (!taskStarted)
            return;
        Movement.anim.Play(axeDown, 0, 0);
        if (slider.value >= 0.88f)
        {
            chopCount++;
            StartSlider();
            Debug.Log("ACERTOU");
        }
        else
            Debug.Log("ERROU");

        if (chopCount >= 3)
        {
            StartCoroutine(EndTask());
        }
        woodenLog.ChangeLogSprite(chopCount);
    }

    private IEnumerator DisableSelf()
    {
        yield return new WaitForEndOfFrame();
        myCanvas.enabled = false;
    }

    private IEnumerator EndTask()
    {
        yield return new WaitForSeconds(chopTime);
        myCanvas.enabled = false;
        Movement.PlayerMovement.canMove = true;
        Movement.anim.Rebind();
        taskStarted = false;
        Destroy(woodenLog.gameObject);
    }

    private void StartSlider()
    {
        slider.value = 0f;
        float gameSpeed;
        switch (chopCount)
        {
            case 0:
                gameSpeed = speed;
                break;
            case 1:
                gameSpeed = speed / 1.5f;
                break;
            case 2:
                gameSpeed = speed / 2f;
                break;
            default:
                gameSpeed = speed;
                break;
        }

        if (chop != null)
            chop.Kill();
        chop = slider.DOValue(1f, gameSpeed);
        chop.SetLoops(-1, LoopType.Yoyo);
        chop.SetEase(Ease.InQuart);
    }
}
