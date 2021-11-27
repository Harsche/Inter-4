using UnityEngine;
using System;

public class BucketTasks : MonoBehaviour
{
    [SerializeField] private bool forWaterTask;
    private const string bucketTrigger = "Bucket";
    private const string waterTaskLuiz = "Luiz_Day_03.D01";
    private Animator playerAnimator;
    private bool waterTaskActive;

    private void Start() {
        playerAnimator = Globals.Player.GetComponent<Animator>();
        if (!forWaterTask)
            return;
        waterTaskActive = DialogManager.VariableStates.waterTask;
        ToggleTask(waterTaskActive);
        Globals.DialogManager.VariablesChanged += WatchTaskState;
    }

    private void OnDestroy()
    {
        if (forWaterTask)
            Globals.DialogManager.VariablesChanged -= WatchTaskState;
    }

    private void ToggleTask(bool toggle)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(toggle);
        }
    }

    private void WatchTaskState(object sender, EventArgs args)
    {
        waterTaskActive = DialogManager.VariableStates.waterTask;
        ToggleTask(waterTaskActive);
    }

    public void PickBucketUp()
    {
        playerAnimator.SetBool(bucketTrigger, true);
        gameObject.SetActive(false);
        if(forWaterTask)
            Globals.DialogManager.StartDialog(waterTaskLuiz);
    }
}
