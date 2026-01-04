using System.Collections;
using UnityEngine;

public class SequentialObjectController : MonoBehaviour
{
    [System.Serializable]
    public class ObjectGroup
    {
        public GameObject[] parentObjectsToEnable;  // Multiple parents to enable
        public GameObject[] parentObjectsToDisable; // Multiple parents to disable
    }

    [SerializeField] ObjectGroup[] objectGroups;  // Store groups of parent objects to enable/disable
    [SerializeField] float delayBetweenGroups = 0.5f;  // Delay between group activations

    void Awake()
    {
        // Initially disable all parent objects
        foreach (var group in objectGroups)
        {
            foreach (var parentObj in group.parentObjectsToEnable)
            {
                if (parentObj != null)
                    parentObj.SetActive(false);  // Disable parent objects
            }

            foreach (var parentObj in group.parentObjectsToDisable)
            {
                if (parentObj != null)
                    parentObj.SetActive(true); // Enable parent objects
            }
        }
    }

    void OnEnable()
    {
        // Subscribe to the event
        EnvironmentEvents.OnArrowStepped += StartSequence;
    }

    void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        EnvironmentEvents.OnArrowStepped -= StartSequence;
    }

    void StartSequence()
    {
        StartCoroutine(ObjectSequence());
    }

    IEnumerator ObjectSequence()
    {
        foreach (var group in objectGroups)
        {
            // Enable all parent objects in the "parentObjectsToEnable" array at the same time
            foreach (var parentObj in group.parentObjectsToEnable)
            {
                if (parentObj != null)
                    parentObj.SetActive(true);
            }

            // Disable all parent objects in the "parentObjectsToDisable" array at the same time
            foreach (var parentObj in group.parentObjectsToDisable)
            {
                if (parentObj != null)
                    parentObj.SetActive(false);
            }

            yield return new WaitForSeconds(delayBetweenGroups); // Wait for the delay before the next group
        }
    }
}
