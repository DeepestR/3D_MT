using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger hit by: " + other.name);

        if (triggered) return;

        if (other.transform.root.CompareTag("Player"))
        {
            triggered = true;
            Debug.Log("Arrow trigger fired");
            EnvironmentEvents.TriggerArrowStepped();
        }
    }

}

