using UnityEngine;

public class BucketTasks : MonoBehaviour
{
    [SerializeField] private bool forWaterTask;
    private const string bucketTrigger = "Bucket";
    private Animator playerAnimator;

    private void Start() {
        playerAnimator = Globals.Player.GetComponent<Animator>();
    }

    public void PickBucketUp()
    {
        playerAnimator.SetBool(bucketTrigger, true);
        gameObject.SetActive(false);
    }
}
