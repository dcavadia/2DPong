using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataConfiguration
{

    const string ConfigurationDataFileName = "DataConfiguration.csv";

    //default
    float paddleMoveUnitsPerSecond = 10;
    float ballImpulseForce = 200;
    float ballLifeSeconds = 10;
    float minSpawnSeconds = 5;
    float maxSpawnSeconds = 10;
    int standardBlockPoints = 1;
    int bonusBlockPoints = 2;
    int pickupBlockPoints = 5;
    float standardBlockProbability = 0.7f;
    float bonusBlockProbability = 0.2f;
    float freezerBlockProbability = 0.05f;
    float speedupBlockProbability = 0.05f;
    int ballsPerGame = 5;


    public DataConfiguration()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            string names = input.ReadLine();
            string values = input.ReadLine();

            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    public float BallImpulseForce
    {
        get { return ballImpulseForce; }
    }

    public float BallLifeSeconds
    {
        get { return ballLifeSeconds; }
    }

    public float MinSpawnSeconds
    {
        get { return minSpawnSeconds; }
    }

    public float MaxSpawnSeconds
    {
        get { return maxSpawnSeconds; }
    }

    public int StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }

    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    public int PickupBlockPoints
    {
        get { return pickupBlockPoints; }
    }

    public float StandardBlockProbability
    {
        get { return standardBlockProbability; }
    }

    public float BonusBlockProbability
    {
        get { return bonusBlockProbability; }
    }

    public float FreezerBlockProbability
    {
        get { return freezerBlockProbability; }
    }

    public float SpeedupBlockProbability
    {
        get { return speedupBlockProbability; }
    }

    public int BallsPerGame
    {
        get { return ballsPerGame; }
    }

    void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeSeconds = float.Parse(values[2]);
        minSpawnSeconds = float.Parse(values[3]);
        maxSpawnSeconds = float.Parse(values[4]);
        standardBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
        pickupBlockPoints = int.Parse(values[7]);
        standardBlockProbability = float.Parse(values[8]) / 100;
        bonusBlockProbability = float.Parse(values[9]) / 100;
        freezerBlockProbability = float.Parse(values[10]) / 100;
        speedupBlockProbability = float.Parse(values[11]) / 100;
        ballsPerGame = int.Parse(values[12]);
    }

}
