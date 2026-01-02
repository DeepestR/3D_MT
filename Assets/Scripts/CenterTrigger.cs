using UnityEngine;

public class CenterTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Player root detected, firing event");
            EnvironmentEvents.TriggerCenterReached();
            gameObject.SetActive(false);
        }
    }

}
