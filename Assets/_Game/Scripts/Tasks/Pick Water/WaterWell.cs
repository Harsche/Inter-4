using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class WaterWell : MonoBehaviour
{
    [SerializeField] private Canvas waterGauge;
    [SerializeField] private WaterSlider waterSlider;
    private const string bucket = "Bucket";
    private const string water = "Water";
    private const string getWater = "Get Water";
    private const string noBucket = "Other_Dialogs.Need_Bucket";
    private Animator playerAnimator;
    private Movement playerMovement;
    private AnimationControl playerAnimationControl;
    private Animator myAnimator;
    private bool taskActive;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        taskActive = DialogManager.VariableStates.waterTask;
        ToggleTask(taskActive);
        Globals.DialogManager.VariablesChanged += WatchTaskState;
    }

    private void Start()
    {
        playerAnimator = Globals.Player.GetComponent<Animator>();
        playerMovement = Globals.Player.GetComponent<Movement>();
        playerAnimationControl = Globals.Player.GetComponent<AnimationControl>();
    }

    private void OnDestroy() {
        Globals.DialogManager.VariablesChanged -= WatchTaskState;
    }

    private void WatchTaskState(object sender, EventArgs args)
    {
        taskActive = DialogManager.VariableStates.waterTask;
        ToggleTask(taskActive);
    }

    private void ToggleTask(bool toggle)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(toggle);
        }
    }

    public void GetWater()
    {
        playerAnimationControl.Idle_Left();
        bool withBucket = playerAnimator.GetBool(bucket);
        if (!withBucket)
        {
            Globals.DialogManager.JumpTo(noBucket);
            Globals.DialogManager.OpenDialog();
            return;
        }
        playerMovement.canMove = false;
        playerAnimator.SetBool(bucket, false);
        myAnimator.SetTrigger(getWater);
        StartCoroutine(WaitForGetWater());
    }

    private IEnumerator WaitForGetWater()
    {
        yield return new WaitForEndOfFrame();
        float wait = myAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(wait);
        playerAnimator.SetBool(bucket, true);
        playerAnimator.SetBool(water, true);
        playerMovement.canMove = true;
        waterGauge.transform.SetParent(Globals.Player.transform);
        waterGauge.transform.localPosition = Vector3.zero;
        waterGauge.enabled = true;
        waterSlider.TakeWater();
    }

}
