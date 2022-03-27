using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static List<Block> pointsAddedInvokers = new List<Block>();
    static List<UnityAction<int>> pointsAddedListeners =
        new List<UnityAction<int>>();

    static List<Ball> ballLostInvokers = new List<Ball>();
    static List<UnityAction> ballLostListeners =
        new List<UnityAction>();

    static List<Ball> ballDiedInvokers = new List<Ball>();
    static List<UnityAction> ballDiedListeners =
        new List<UnityAction>();

    static List<HUD> lastBallLostInvokers = new List<HUD>();
    static List<UnityAction> lastBallLostListeners =
        new List<UnityAction>();

    static List<Block> blockDestroyedInvokers = new List<Block>();
    static List<UnityAction> blockDestroyedListeners =
        new List<UnityAction>();

    static List<PickupBlock> freezerEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerEffectListeners =
        new List<UnityAction<float>>();

    static List<PickupBlock> speedupEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float, float>> speedupEffectListeners =
        new List<UnityAction<float, float>>();


    public static void AddPointsAddedInvoker(Block invoker)
    {
        pointsAddedInvokers.Add(invoker);
        foreach (UnityAction<int> listener in pointsAddedListeners)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    public static void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsAddedListeners.Add(listener);
        foreach (Block invoker in pointsAddedInvokers)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    public static void AddBallLostInvoker(Ball invoker)
    {
        ballLostInvokers.Add(invoker);
        foreach (UnityAction listener in ballLostListeners)
        {
            invoker.AddBallLostListener(listener);
        }
    }

    public static void AddBallLostListener(UnityAction listener)
    {
        ballLostListeners.Add(listener);
        foreach (Ball invoker in ballLostInvokers)
        {
            invoker.AddBallLostListener(listener);
        }
    }

    public static void AddBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Add(invoker);
        foreach (UnityAction listener in ballDiedListeners)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    public static void AddBallDiedListener(UnityAction listener)
    {
        ballDiedListeners.Add(listener);
        foreach (Ball invoker in ballDiedInvokers)
        {
            invoker.AddBallDiedListener(listener);
        }
    }

    public static void AddLastBallLostInvoker(HUD invoker)
    {
        lastBallLostInvokers.Add(invoker);
        foreach (UnityAction listener in lastBallLostListeners)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    public static void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLostListeners.Add(listener);
        foreach (HUD invoker in lastBallLostInvokers)
        {
            invoker.AddLastBallLostListener(listener);
        }
    }

    public static void AddBlockDestroyedInvoker(Block invoker)
    {
        blockDestroyedInvokers.Add(invoker);
        foreach (UnityAction listener in blockDestroyedListeners)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }

    public static void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestroyedListeners.Add(listener);
        foreach (Block invoker in blockDestroyedInvokers)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }

    public static void AddFreezerEffectInvoker(PickupBlock invoker)
    {
        freezerEffectInvokers.Add(invoker);
        foreach (UnityAction<float> listener in freezerEffectListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    public static void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectListeners.Add(listener);
        foreach (PickupBlock invoker in freezerEffectInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    public static void AddSpeedupEffectInvoker(PickupBlock invoker)
    {
        speedupEffectInvokers.Add(invoker);
        foreach (UnityAction<float, float> listener in speedupEffectListeners)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    public static void AddSpeedupEffectListener(UnityAction<float, float> listener)
    {
        speedupEffectListeners.Add(listener);
        foreach (PickupBlock invoker in speedupEffectInvokers)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

}
