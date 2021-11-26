using UnityEngine;

public class LostKey : MonoBehaviour
{
    [SerializeField] private CircleCollider2D interactionTrigger;
    private SpriteRenderer mySpriteRenderer;
    private const string lostKey = "lostKey";

    private void Awake()
    {
        bool foundKey = (bool)Globals.DialogManager.story.variablesState["lostKey"];
        if(foundKey)
            Destroy(gameObject);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FindKey()
    {
        Globals.DialogManager.ChangeStoryVariable<bool>(lostKey, true);
        mySpriteRenderer.enabled = false;
        interactionTrigger.enabled = false;
    }
}
