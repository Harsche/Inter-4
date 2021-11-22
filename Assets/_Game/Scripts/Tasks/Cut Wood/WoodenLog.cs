using UnityEngine;
using UnityEngine.Playables;

public class WoodenLog : MonoBehaviour
{
    [SerializeField] private Sprite[] logSprites;
    [SerializeField] private ChopTask chopTask;
    private Movement playerMovement;
    private SpriteRenderer mySpriteRenderer;
    private PlayableDirector myPlayableDirector;
    private static bool playerWithAxe;
    private const string axeUp = "Luiz_Subindo_Machado";
    private const string noAxe = "Other_Dialogs.Need_Axe";

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myPlayableDirector = GetComponent<PlayableDirector>();

    }

    private void Start()
    {
        playerMovement = Globals.Player.GetComponent<Movement>();
    }

    public void ChangeAxe()
    {
        Animator playerAnimator = Movement.anim;
        playerWithAxe = !playerWithAxe;
        playerAnimator.SetBool("Axe", playerWithAxe);
        int spriteIndex = playerWithAxe ? 0 : 1;
        mySpriteRenderer.sprite = logSprites[spriteIndex];
    }

    public void PlayCutscene()
    {
        if (!playerWithAxe)
        {
            Globals.DialogManager.JumpTo(noAxe);
            Globals.DialogManager.OpenDialog();
            return;
        }
        if (myPlayableDirector != null)
            myPlayableDirector.Play();
        Movement.boxCollider2D.enabled = false;
        playerMovement.canMove = false;

    }

    public void ChangeLogSprite(int index)
    {
        if (index < 3)
            mySpriteRenderer.sprite = logSprites[index];
    }

    public void ReadyToCutWood()
    {
        Player.animationControl.PlayByName(axeUp);
        chopTask.StartTask();
    }
}
