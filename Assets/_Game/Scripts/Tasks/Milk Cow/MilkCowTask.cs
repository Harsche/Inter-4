using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Lean.Touch;
using DG.Tweening;

public class MilkCowTask : MonoBehaviour
{
    [SerializeField] private int timesToMilk = 10;
    [SerializeField] Animator milkAnimator;
    [SerializeField] Animator backgroundAnimator;
    [SerializeField] private float timeToDisable = 0.3f;
    [SerializeField] private LeanTouch leanTouch;
    [SerializeField] private LeanFingerSwipeAuto leanSwipeDown;
    [SerializeField] private LeanFingerSwipeAuto leanSwipeUp;
    [SerializeField] private Slider milkSlider;
    private Canvas taskCanvas;
    private const float animationTime = 31 / 60f;
    private const string noBucket = "Other_Dialogs.Need_Bucket";
    private const string bucket = "Bucket";
    private const string milk = "Milk";
    private bool milkLeftOrRight;
    private Swiped swipedUp = new Swiped();
    private Swiped swipedDown = new Swiped();
    private float milkAmount;

    private void Awake()
    {
        taskCanvas = GetComponent<Canvas>();
        taskCanvas.enabled = true;
        milkAmount = 0;
        milkSlider.value = milkAmount;
    }

    public void TriggerTask()
    {
        if (!Movement.anim.GetBool(bucket))
        {
            Globals.DialogManager.StartDialog(noBucket);
            return;
        }
        if (DialogManager.GameDay == 1)
        {
            CutsceneManager.TriggerCutscene(2);
            return;
        }
        CutsceneManager.TriggerCutscene(07.5f);
    }

    public void StartTask()
    {
        taskCanvas.enabled = true;
        Globals.Player.transform.Find("LeanTouch").gameObject.SetActive(false);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void EndTask()
    {
        taskCanvas.enabled = false;
        Globals.Player.transform.Find("LeanTouch").gameObject.SetActive(true);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        Movement.anim.SetBool(milk, true);
        if(DialogManager.GameDay == 2)
            Globals.DialogManager.StartDialog("Cow");
    }

    public void SwipeUp(LeanFinger finger)
    {
        if (LeanTouch.Fingers.Count != 2)
            return;
        if (swipedUp.swiped)
            return;
        Debug.Log("UP");
        swipedUp.swiped = true;
        StartCoroutine(DisableSwiped(swipedUp));
        leanSwipeUp.passedThreshold = true;
        leanSwipeUp.lastPosition = finger.ScreenPosition;
        StartCoroutine(ResetLeanSwipe(leanSwipeUp));
        TakeMilk();
    }

    public void SwipeDown(LeanFinger finger)
    {
        if (LeanTouch.Fingers.Count != 2)
            return;
        if (swipedDown.swiped)
            return;
        Debug.Log("DOWN");
        swipedDown.swiped = true;
        StartCoroutine(DisableSwiped(swipedDown));
        leanSwipeDown.passedThreshold = true;
        leanSwipeDown.lastPosition = finger.ScreenPosition;
        StartCoroutine(ResetLeanSwipe(leanSwipeDown));
        TakeMilk();
    }

    public void TakeMilk()
    {
        if (Mathf.Equals(milkAmount, 1f) || milkAmount > 1f)
            return;
        if (!(swipedUp.swiped && swipedDown.swiped))
            return;
        milkAmount += 1f / timesToMilk;
        DoMilkAnimation();
        float tweenValue = 0f;
        if (DialogManager.GameDay == 1)
            tweenValue = milkAmount;
        if (DialogManager.GameDay == 2)
            tweenValue = Mathf.Clamp(milkAmount, 0f, 0.4f);
        Tween gaugeTween = milkSlider.DOValue(tweenValue, 0.3f); 
        gaugeTween.OnComplete(() => CheckAmount());
    }

    public void CheckAmount()
    {
        if (Mathf.Equals(milkAmount, 1f) || milkAmount > 1f)
            EndTask();
    }

    public void DoMilkAnimation()
    {
        string trigger = milkLeftOrRight ? "Left" : "Right";
        backgroundAnimator.SetTrigger(trigger);
        milkLeftOrRight = !milkLeftOrRight;
        if(DialogManager.GameDay == 2 && milkAmount > 0.4f)
            return;
        milkAnimator.SetTrigger(trigger);
    }

    private IEnumerator DisableCanvas()
    {
        yield return new WaitForEndOfFrame();
        taskCanvas.enabled = false;
    }

    public IEnumerator DisableSwiped(Swiped swiped)
    {
        yield return new WaitForSeconds(timeToDisable);
        swiped.swiped = false;
    }

    public IEnumerator ResetLeanSwipe(LeanFingerSwipeAuto leanFingerSwipeAuto)
    {
        leanFingerSwipeAuto.enabled = false;
        yield return new WaitForSeconds(timeToDisable);
        leanFingerSwipeAuto.enabled = true;
    }
}

public class Swiped
{
    public bool swiped;
}