using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static List<PickupBlock> freezerEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerEffectListeners =
        new List<UnityAction<float>>();

    static List<PickupBlock> speedupEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float, float>> speedupEffectListeners =
        new List<UnityAction<float, float>>();


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
