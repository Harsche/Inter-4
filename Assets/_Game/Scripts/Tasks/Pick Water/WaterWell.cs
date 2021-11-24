using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaterWell : MonoBehaviour
{
    [SerializeField] private GameObject waterGauge;
    [SerializeField] private Slider waterSlider;
    private const string bucket = "Bucket";
    private const string water = "Water";
    private const string getWater = "Get Water";
    private const string noBucket = "Other_Dialogs.Need_Bucket";
    private Animator playerAnimator;
    private Movement playerMovement;
    private AnimationControl playerAnimationControl;
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        playerAnimator = Globals.Player.GetComponent<Animator>();
        playerMovement = Globals.Player.GetComponent<Movement>();
        playerAnimationControl = Globals.Player.GetComponent<AnimationControl>();
    }

    public void GetWater()
    {
        playerAnimationControl.Idle_Left();
        bool withBucket = playerAnimator.GetBool(bucket);
        if (!withBucket)
        {
            Globals.DialogManager.JumpTo(noBucket);
            Globals.DialogManager.OpenDialog();
            return;
        }
        playerMovement.canMove = false;
        playerAnimator.SetBool(bucket, false);
        myAnimator.SetTrigger(getWater);
        StartCoroutine(WaitForGetWater());
    }

    private IEnumerator WaitForGetWater()
    {
        yield return new WaitForEndOfFrame();
        float wait = myAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(wait);
        Debug.Log("END");
        playerAnimator.SetBool(bucket, true);
        playerAnimator.SetBool(water, true);
        playerMovement.canMove = true;
        waterGauge.transform.SetParent(Globals.Player.transform);
        waterGauge.transform.localPosition = Vector3.zero;
        waterSlider.value = 1f;
        waterGauge.SetActive(true);
    }

}
