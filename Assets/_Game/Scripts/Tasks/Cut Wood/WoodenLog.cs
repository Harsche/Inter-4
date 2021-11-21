using UnityEngine;

public class WoodenLog : MonoBehaviour
{
    [SerializeField] private Sprite[] logSprites;
    private SpriteRenderer mySpriteRenderer;
    private static bool playerWithAxe;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeAxe()
    {
        Animator playerAnimator = Movement.anim;
        playerWithAxe = !playerWithAxe;
        playerAnimator.SetBool("Axe", playerWithAxe);
        int spriteIndex = playerWithAxe ? 0 : 1;
        mySpriteRenderer.sprite = logSprites[spriteIndex];
    }
}
