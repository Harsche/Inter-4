using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class WaterBox : MonoBehaviour
{
    [SerializeField] private Canvas waterGauge;
    [SerializeField] private Slider boxSlider;
    [SerializeField] private float fillDuration = 0.5f;
    private const string water = "Water";
    private AnimationControl playerAnimationControl;
    private Animator playerAnimator;
    private Tween fillBox;
    private Movement playerMovement;
    private bool taskActive;

    private void Awake()
    {
        boxSlider.value = 0f;
    }

    private void Start() {
        playerAnimationControl = Globals.Player.GetComponent<AnimationControl>();
        playerAnimator = Globals.Player.GetComponent<Animator>();
        playerMovement = Globals.Player.GetComponent<Movement>();
        taskActive = DialogManager.VariableStates.waterTask;
        ToggleTask(taskActive);
        Globals.DialogManager.VariablesChanged += WatchTaskState;
    }

    private void WatchTaskState(object sender, EventArgs args)
    {
        taskActive = DialogManager.VariableStates.waterTask;
        ToggleTask(taskActive);
    }

    private void OnDestroy() {
        Globals.DialogManager.VariablesChanged -= WatchTaskState;
    }

    private void ToggleTask(bool toggle)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(toggle);
        }
    }

    public void FillWaterBox()
    {
        if (!(WaterSlider.withWater))
            return;
        if (boxSlider.value == 0)
            waterGauge.enabled = true;
        playerAnimationControl.Idle_Left();
        playerMovement.canMove = false;
        float deliveredAmount = WaterSlider.Instance.DeliverWater(fillDuration);
        float currentAmount = boxSlider.value + deliveredAmount;
        fillBox = boxSlider.DOValue(currentAmount, fillDuration);
        fillBox.SetEase(Ease.Linear);
        fillBox.OnComplete(() => OnFillComplete());
        WaterSlider.withWater = false;
    }

    private void OnFillComplete()
    {
        WaterSlider.Instance.DisableGauge();
        playerMovement.canMove = true;
        playerAnimator.SetBool(water, false);
        if(boxSlider.value >= 1)
        {
            Globals.DialogManager.story.variablesState["waterTask"] = false;
            Globals.DialogManager.story.variablesState["filledWaterBox"] = true;
            Globals.CutsceneManager.SetCutscenePlayable("18");
        }
            
    }
}
