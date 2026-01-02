using UnityEngine;

public class TunnelController : MonoBehaviour
{
    void OnEnable()
    {
        EnvironmentEvents.OnCenterReached += DisableTunnel;
    }

    void OnDisable()
    {
        EnvironmentEvents.OnCenterReached -= DisableTunnel;
    }

    void DisableTunnel()
    {
        gameObject.SetActive(false);
    }
}
