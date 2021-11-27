using UnityEngine;
using System;
using System.Collections;

public class ChickenFence : MonoBehaviour
{
    [SerializeField] private float waitBeforeStopping;
    private BoxCollider2D boxCollider2D;
    private int chickenCount;
    private bool taskActive;
    
    private void Awake() {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
    }

    void Start()
    {
        taskActive = DialogManager.VariableStates.chickenTask;
        Globals.DialogManager.VariablesChanged += WatchTaskActivated;
        ToggleTask(taskActive);
    }

    private void OnDestroy() {
        Globals.DialogManager.VariablesChanged -= WatchTaskActivated;
    }

    private void GetChicken()
    {
        chickenCount++;
        Debug.Log(chickenCount);
        if(chickenCount >= 5)
            Globals.DialogManager.story.variablesState["chickenTask"] = false;
            Globals.DialogManager.story.variablesState["returnedChicken"] = false;
    }

    private void ToggleTask(bool toggle)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(toggle);
            boxCollider2D.enabled = toggle;
        }
    }

    private void WatchTaskActivated(object sender, EventArgs args)
    {
        taskActive = DialogManager.VariableStates.chickenTask;
        ToggleTask(taskActive);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.isTrigger)
            return;
        if(!(other.name.Contains("Chicken")))
            return;
        StartCoroutine(StopChicken(other));
    }

    private IEnumerator StopChicken(Collider2D chicken)
    {
        chicken.transform.GetChild(0).gameObject.SetActive(false);
        chicken.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetChicken();
        yield return new WaitForSeconds(waitBeforeStopping);
    }
}
