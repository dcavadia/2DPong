using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataConfiguration
{

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    //default
    float paddleMoveUnitsPerSecond = 10;
    float ballImpulseForce = 200;


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

    void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
    }

}
