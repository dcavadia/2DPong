using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{

    public static bool SpeedupEffectActive
    {
        get { return GetSpeedupEffectMonitor().SpeedupEffectActive; }
    }

    public static float SpeedupEffectSecondsLeft
    {
        get { return GetSpeedupEffectMonitor().SpeedupEffectSecondsLeft; }
    }

    public static float SpeedupFactor
    {
        get { return GetSpeedupEffectMonitor().SpeedupFactor; }
    }

    static SpeedupEffectMonitor GetSpeedupEffectMonitor()
    {
        return Camera.main.GetComponent<SpeedupEffectMonitor>();
    }
}
