using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    public static DayTime DayTime = DayTime.Day;

    
}

public enum DayTime
{
    Day,
    Night
}

public class DayTimeData
{
    public DayTime dayTime;
}
