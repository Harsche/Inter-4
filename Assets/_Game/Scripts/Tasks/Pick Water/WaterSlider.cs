using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WaterSlider : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Slider mySlider;
    private Canvas myCanvas;
    public static WaterSlider Instance { get; private set; }
    public static bool withWater;
    private Tween sliderDown;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        myCanvas = GetComponent<Canvas>();
    }

    public void DisableGauge()
    {
        myCanvas.enabled = false;
    }

    public void TakeWater()
    {
        mySlider.value = 1;
        sliderDown = mySlider.DOValue(0, duration);
        sliderDown.SetEase(Ease.Linear);
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
