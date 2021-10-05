using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : MonoBehaviour
{
    [SerializeField] private float checkFrequency;
    [SerializeField] private float maxDistance;
    [SerializeField] private float minDistance;
    private AnimationControl animationControl;
    private Coroutine distance;
    private bool isWithinDistance;
    private bool isWaiting;


    void Start()
    {
        distance = StartCoroutine(CheckDistanceFromPlayer());
        animationControl = GetComponent<AnimationControl>();
    }

    private IEnumerator CheckDistanceFromPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkFrequency);
            if(isWithinDistance && Vector2.Distance(transform.position, Globals.Player.transform.position) > maxDistance)
            {
                isWithinDistance = false;
                Globals.CutsceneManager.PauseTimeline();
                animationControl.Idle_Left();
                Globals.DialogCanvas.GetComponent<DialogManager>().JumpTo("Day_01_Scene_02");
                Globals.DialogCanvas.GetComponent<DialogManager>().ContinueStory();
                Globals.DialogCanvas.SetActive(true);
            }
            else if(!isWithinDistance && Vector2.Distance(transform.position, Globals.Player.transform.position) < minDistance)
            {
                isWithinDistance = true;
                Globals.CutsceneManager.ResumeTimeline();
                if(!isWaiting)
                {
                    animationControl.Walk_Right();
                }
            }
        }
    }

    public void StopCheckingDistance()
    {
        StopCoroutine(distance);
    }

    public void SetWaiting()
    {
        isWaiting = true;
    }
}
