using UnityEngine;
using UnityEngine.Playables;

public class WoodenLog : MonoBehaviour
{
    [SerializeField] private Sprite[] logSprites;
    private SpriteRenderer mySpriteRenderer;
    private PlayableDirector myPlayableDirector;
    private static bool playerWithAxe;
    private const string axeUp = "Luiz_Subindo_Machado";
    private const string axeDown = "Luiz_Cortando_Lenha";

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myPlayableDirector = GetComponent<PlayableDirector>();
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
        Movement.canMove = false;

    }

    public void OnCutsceneFinished()
    {
        Player.animationControl.PlayByName(axeUp);
    }
}
