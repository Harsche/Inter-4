using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WaterSlider : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Slider mySlider;
    public static WaterSlider Instance { get; private set; }
    public static bool withWater;
    private Tween sliderDown;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void OnEnable() {
        TakeWater();
    }

    public void DisableGauge()
    {
        gameObject.SetActive(false);
    }

    public void TakeWater()
    {
        sliderDown = mySlider.DOValue(0, duration);
        withWater = true;
    }

    public float DeliverWater(float fillDuration)
    {
        if(sliderDown != null)
            sliderDown.Kill();
        float waterAmount = mySlider.value;
        sliderDown = mySlider.DOValue(0, fillDuration);
        return waterAmount;
    }
}
