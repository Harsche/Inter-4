using UnityEngine;

public class Village : MonoBehaviour
{
    [SerializeField] private VillageSetupData[] villageDayData;
    

    void Awake() {
        
    }
}

public enum DayTime
{
    Day,
    Afternoon,
    Night
}