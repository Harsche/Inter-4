using UnityEngine;
using UnityEngine.Playables;

public class WoodenLog : MonoBehaviour
{
    [SerializeField] private Sprite[] logSprites;
    private SpriteRenderer mySpriteRenderer;
    private PlayableDirector myPlayableDirector;
    private static bool playerWithAxe;

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
        //Movement.anim.applyRootMotion = true;
    }
}
