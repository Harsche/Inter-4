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

    public void StartTask()
    {
        taskCanvas.enabled = true;
        for(int i = 0; i < transform.childCount; i++)
        {
            //transform.
        }
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
        if (!(swipedUp.swiped && swipedDown.swiped))
            return;
        DoMilkAnimation();
        milkAmount += 1f/timesToMilk;
        milkSlider.DOValue(milkAmount, 0.3f);
    }

    public void DoMilkAnimation()
    {
        string trigger = milkLeftOrRight ? "Left" : "Right";
        milkAnimator.SetTrigger(trigger);
        backgroundAnimator.SetTrigger(trigger);
        milkLeftOrRight = !milkLeftOrRight;
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