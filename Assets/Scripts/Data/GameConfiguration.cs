using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConfiguration
{
    static DataConfiguration dataConfiguration;

    public static void Initialize()
    {
        dataConfiguration = new DataConfiguration();
    }

    public static float PaddleMoveUnitsPerSecond
    {
        get { return dataConfiguration.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return dataConfiguration.BallImpulseForce; }
    }

}
