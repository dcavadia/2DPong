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

    public static float BallLifeSeconds
    {
        get { return dataConfiguration.BallLifeSeconds; }
    }
        
    public static float MinSpawnSeconds
    {
        get { return dataConfiguration.MinSpawnSeconds; }    
    }

    public static float MaxSpawnSeconds
    {
        get { return dataConfiguration.MaxSpawnSeconds; }    
    }

    public static int StandardBlockPoints
    {
        get { return dataConfiguration.StandardBlockPoints; }    
    }
        
    public static int BonusBlockPoints
    {
        get { return dataConfiguration.BonusBlockPoints; }    
    }

    public static int PickupBlockPoints
    {
        get { return dataConfiguration.PickupBlockPoints; }    
    }

    public static float StandardBlockProbability
    {
        get { return dataConfiguration.StandardBlockProbability; }    
    }

    public static float BonusBlockProbability
    {
        get { return dataConfiguration.BonusBlockProbability; }    
    }

    public static float FreezerBlockProbability
    {
        get { return dataConfiguration.FreezerBlockProbability; }    
    }

    public static float SpeedupBlockProbability
    {
        get { return dataConfiguration.SpeedupBlockProbability; }    
    }

    public static int BallsPerGame
    {
        get { return dataConfiguration.BallsPerGame; }    
    }

}
