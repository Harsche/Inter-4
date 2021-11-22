using UnityEngine;
using UnityEngine.Playables;

public class WoodenLog : MonoBehaviour
{
    [SerializeField] private Sprite[] logSprites;
    private Movement playerMovement;
    private SpriteRenderer mySpriteRenderer;
    private PlayableDirector myPlayableDirector;
    private static bool playerWithAxe;
    private const string axeUp = "Luiz_Subindo_Machado";
    private const string axeDown = "Luiz_Cortando_Lenha";

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myPlayableDirector = GetComponent<PlayableDirector>();
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
        if(myPlayableDirector != null)
            myPlayableDirector.Play();
        Movement.boxCollider2D.enabled = false;
        playerMovement.canMove = false;

    }

    public void OnCutsceneFinished()
    {
        Player.animationControl.PlayByName(axeUp);
    }
}
