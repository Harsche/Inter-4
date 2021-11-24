using UnityEngine;
using UnityEngine.Playables;
using DG.Tweening;

public class WoodenLog : MonoBehaviour
{
    [SerializeField] private Sprite[] logSprites;
    [SerializeField] private ChopTask chopTask;
    [SerializeField] private Transform chopPosition;
    private Rigidbody2D playerRigidbody2D;
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
        playerRigidbody2D = Globals.Player.GetComponent<Rigidbody2D>();
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
        Debug.Log("CHANGED");
        Movement.boxCollider2D.enabled = false;
        playerMovement.canMove = false;
        Tween goToPosition = playerRigidbody2D.DOMove(chopPosition.position, 0.2f);
        goToPosition.SetEase(Ease.Linear);
        goToPosition.OnComplete(() => ReadyToCutWood());
    }

    public void ChangeLogSprite(int index)
    {
        if (index < 3)
            mySpriteRenderer.sprite = logSprites[index];
    }

    public void ReadyToCutWood()
    {
        Player.animationControl.PlayByName(axeUp);
        Player.animationControl.spriteRenderer.flipX = false;
        chopTask.StartTask();
    }
}
