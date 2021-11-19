using System.Collections;
using UnityEngine;

public class CheckDistance : MonoBehaviour
{
    [SerializeField] private float checkFrequency;
    [SerializeField] private float maxDistance;
    [SerializeField] private float minDistance;
    [SerializeField] private Cutscene cutscene;
    private const string idleAnimationName = "DonaMaria_Idle_Bucket_Empty";
    private const string walkingAnimationName = "DonaMaria_Walking_Bucket_Empty";
    private AnimationControl animationControl;
    private SpriteRenderer mySpriteRenderer;
    private Coroutine distance;
    private bool isWithinDistance;
    private bool isWaiting;
    


    void Start()
    {
        //Obtém os componentes e começa a coroutine de checar distância
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        distance = StartCoroutine(CheckDistanceFromPlayer());
        animationControl = GetComponent<AnimationControl>();
        isWithinDistance = true;
    }

    private IEnumerator CheckDistanceFromPlayer()
    {
        //Checa a ditância do jogador até este objeto
        if(cutscene == null)
            cutscene = Globals.CutsceneManager.currentCutscene;
        while (true)
        {
            yield return new WaitForSeconds(checkFrequency);
            if (isWithinDistance && Vector2.Distance(transform.position, Globals.Player.transform.position) > maxDistance)
            {
                isWithinDistance = false;
                Globals.CutsceneManager.PauseTimeline();
                cutscene.BindOrUnbindTracks("Dona Maria", false, gameObject);
                animationControl.PlayByName(idleAnimationName);
                mySpriteRenderer.flipX = true;
                Globals.DialogCanvas.GetComponent<DialogManager>().JumpTo("Day_01_Scene_02");
                Globals.DialogCanvas.GetComponent<DialogManager>().ContinueStory();
                Globals.DialogManager.OpenDialog();
            }
            else if (!isWithinDistance && Vector2.Distance(transform.position, Globals.Player.transform.position) < minDistance)
            {
                isWithinDistance = true;
                Globals.CutsceneManager.ResumeTimeline();
                if (!isWaiting)
                {
                    mySpriteRenderer.flipX = false;
                    cutscene.BindOrUnbindTracks("Dona Maria", true, gameObject);
                    animationControl.PlayByName(walkingAnimationName);
                }
            }
        }
    }

    public void StopCheckingDistance()
    {
        if (distance != null) StopCoroutine(distance);
    }

    public void SetWaiting()
    {
        //Diz que o objeto chegou na posição final
        isWaiting = true;
    }
}
