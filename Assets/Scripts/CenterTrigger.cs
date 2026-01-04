using UnityEngine;

public class CenterTrigger : MonoBehaviour
{
    bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger hit by: " + other.name);

        if (triggered) return; // Prevents the event from being triggered more than once

        if (other.transform.root.CompareTag("Player"))
        {
            triggered = true; // Mark as triggered to prevent repeat triggers
            Debug.Log("Center trigger fired");

            // Fire the event
            EnvironmentEvents.TriggerCenterReached();

            gameObject.SetActive(false); // Disable the trigger after activation
        }
    }
}
