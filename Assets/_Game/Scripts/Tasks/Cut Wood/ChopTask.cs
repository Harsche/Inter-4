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
    private LeanFingerDown leanFingerDown;
    private bool taskStarted;
    private const string axeDown = "Luiz_Cortando_Lenha";
    private float chopLength;
    private int chopCount;
    private Canvas myCanvas;
    private Tween chop;
    private static bool sawTutorial;

    private void Awake()
    {
        myCanvas = GetComponent<Canvas>();
        leanFingerDown = GetComponent<LeanFingerDown>();
        StartCoroutine(DisableSelf());
    }

    public void StartTask()
    {
        chopCount = 0;
        Movement.PlayerMovement.spriteRenderer.flipX = false;
        myCanvas.enabled = true;
        StartSlider();
        taskStarted = true;
        if(!sawTutorial)
        {
            Tutorials.Instance.ShowTutorial(TutorialType.Wood);
            sawTutorial = true;
        }
    }

    public void TryToChop(LeanFinger finger)
    {
        if (!taskStarted)
            return;
        Movement.anim.Play(axeDown, 0, 0);
        leanFingerDown.enabled = false;
        StartCoroutine(WaitToChopAgain());
        if (slider.value >= 0.88f)
        {
            chopCount++;
            StartSlider();
            Globals.DialogManager.story.variablesState["woodChopped"] = chopCount;
        }
        if (chopCount >= 3)
        {
            StartCoroutine(EndTask());
        }
        woodenLog.ChangeLogSprite(chopCount);
    }

    private IEnumerator WaitToChopAgain()
    {
        yield return new WaitForEndOfFrame();
        chopLength = Movement.anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(chopLength);
        leanFingerDown.enabled = true;
    }

    private IEnumerator DisableSelf()
    {
        yield return new WaitForEndOfFrame();
        myCanvas.enabled = false;
    }

    private IEnumerator EndTask()
    {
        yield return new WaitForSeconds(chopLength);
        myCanvas.enabled = false;
        Movement.PlayerMovement.canMove = true;
        Movement.PlayerMovement.animateByTransform = true;
        Movement.anim.Rebind();
        Movement.anim.SetBool("Axe", true);
        taskStarted = false;
        Movement.boxCollider2D.enabled = true;
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
