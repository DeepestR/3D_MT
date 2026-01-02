using System;

public static class EnvironmentEvents
{
    public static Action OnCenterReached;

    public static void TriggerCenterReached()
    {
        OnCenterReached?.Invoke();
    }
}
