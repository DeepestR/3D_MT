using System;
using UnityEngine;

public static class EnvironmentEvents
{
    public static Action OnCenterReached;
    public static Action OnArrowStepped;

    public static void TriggerCenterReached()
    {
        Debug.Log("CenterReached event triggered");
        OnCenterReached?.Invoke();
    }

    public static void TriggerArrowStepped()
    {
        Debug.Log("ArrowStepped event triggered");
        OnArrowStepped?.Invoke();
    }
}
