using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WaterBox : MonoBehaviour
{
    [SerializeField] private GameObject waterGauge;
    [SerializeField] private Slider boxSlider;
    [SerializeField] private float fillDuration = 0.5f;
    private const string water = "Water";
    private AnimationControl playerAnimationControl;
    private Animator playerAnimator;
    private Tween fillBox;
    private Movement playerMovement;

    private void Awake()
    {
        boxSlider.value = 0f;
    }

    private void Start()
    {
        playerAnimationControl = Globals.Player.GetComponent<AnimationControl>();
        playerAnimator = Globals.Player.GetComponent<Animator>();
        playerMovement = Globals.Player.GetComponent<Movement>();
    }

    public void FillWaterBox()
    {
        if (!(WaterSlider.withWater))
            return;
        if (boxSlider.value == 0)
            waterGauge.gameObject.SetActive(true);
        playerAnimationControl.Idle_Left();
        playerMovement.canMove = false;
        float deliveredAmount = WaterSlider.Instance.DeliverWater(fillDuration);
        float currentAmount = boxSlider.value + deliveredAmount;
        fillBox = boxSlider.DOValue(currentAmount, fillDuration);
        fillBox.SetEase(Ease.Linear);
        fillBox.OnComplete(() => OnFillComplete());
        WaterSlider.withWater = false;
    }

    private void OnFillComplete()
    {
        WaterSlider.Instance.DisableGauge();
        playerMovement.canMove = true;
        playerAnimator.SetBool(water, false);
    }
}
