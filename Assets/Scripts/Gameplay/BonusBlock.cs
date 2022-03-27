using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    override protected void Start()
    {
        base.Start();

        // set points
        points = GameConfiguration.BonusBlockPoints;
    }
}
