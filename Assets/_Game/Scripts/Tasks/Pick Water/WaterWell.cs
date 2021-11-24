using UnityEngine;

public class WaterWell : MonoBehaviour
{
    private const string bucketParameter = "Bucket";
    private Animator playerAnimator;

    private void Awake() {
        playerAnimator = Globals.Player.GetComponent<Animator>();
    }

    public void GetWater()
    {
        bool withBucket = playerAnimator.GetBool(bucketParameter);
    }
}
