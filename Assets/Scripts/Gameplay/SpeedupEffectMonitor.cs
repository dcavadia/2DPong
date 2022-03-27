using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    Timer speedupEffectTimer;
    float speedupFactor;

    public bool SpeedupEffectActive
    {
        get { return speedupEffectTimer.Running; }
    }

    public float SpeedupEffectSecondsLeft
    {
        get { return speedupEffectTimer.SecondsLeft; }
    }

    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    void Start()
    {
        speedupEffectTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedupEffectListener(HandleSpeedupEffectActivatedEvent);
    }

    void Update()
    {
        if (speedupEffectTimer.Finished)
        {
            speedupEffectTimer.Stop();
            speedupFactor = 1;
        }
    }

    void HandleSpeedupEffectActivatedEvent(float duration, float speedupFactor)
    {
        if (!speedupEffectTimer.Running)
        {
            this.speedupFactor = speedupFactor;
            speedupEffectTimer.Duration = duration;
            speedupEffectTimer.Run();
        }
        else
        {
            speedupEffectTimer.AddTime(duration);
        }
    }
}
