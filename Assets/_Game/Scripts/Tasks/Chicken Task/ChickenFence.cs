using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ChickenFence : MonoBehaviour
{
    [SerializeField] private float waitBeforeStopping;
    [SerializeField] private Chicken[] chickens;
    private static HashSet<int> returnedChickens;
    private BoxCollider2D boxCollider2D;
    private static int chickenCount;
    private bool taskActive;
    
    private void Awake() {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;;
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

    private void GetChicken(Chicken chicken)
    {
        chickenCount++;
        returnedChickens.Add(chicken.chickenTaskNumber);
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
        if(!toggle)
            return;
        foreach(Chicken chicken in chickens)
        {
            if(returnedChickens.Contains(chicken.chickenTaskNumber))
                chicken.gameObject.SetActive(true);
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
        Chicken whichChicken = chicken.GetComponent<Chicken>();
        GetChicken(whichChicken);
        yield return new WaitForSeconds(waitBeforeStopping);
    }
}
