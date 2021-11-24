using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SceneSetup : MonoBehaviour
{
    [SerializeField] private bool insideHouse;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private GameObject[] lightsToEnable;
    private DayTime currentTime;
    private static Color dayColor = Color.white;
    private static Color nightColor = new Color(0.3161267f, 0.442517f, 0.6037736f, 1f);

    private void Awake()
    {
        currentTime = Player.playerData.dayTime;
        SetupSceneLights();
    }

    private void SetupSceneLights()
    {
        Color sceneColor = ChooseGlobalColor();
        globalLight.color = sceneColor;
        if(currentTime == DayTime.Day)
            return;
        foreach (GameObject obj in lightsToEnable)
            obj.SetActive(true);
    }

    private Color ChooseGlobalColor()
    {
        if (insideHouse)
            return dayColor;
        switch (currentTime)
        {
            case DayTime.Day:
                return dayColor;
            case DayTime.Night:
                return nightColor;
            default:
                return dayColor;

        }
    }
}

public enum DayTime
{
    Day,
    Night
}
