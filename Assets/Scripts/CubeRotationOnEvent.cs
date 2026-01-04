using UnityEngine;

public class CubeRotationOnEvent : MonoBehaviour
{
    public float rotationSpeed = 90f; // Degrees per second
    private bool isRotating = false;
    private Vector3 rotationDirection; // Random rotation direction
    private float rotationProgress = 0f; // Track the progress toward the target rotation

    void OnEnable()
    {
        // Subscribe to the event when the script is enabled
        EnvironmentEvents.OnCenterReached += StartRotation;
    }

    void OnDisable()
    {
        // Unsubscribe from the event when the script is disabled
        EnvironmentEvents.OnCenterReached -= StartRotation;
    }

    void Update()
    {
        // Rotate the cube indefinitely when the event is triggered
        if (isRotating)
        {
            // Apply smooth continuous rotation along multiple axes (randomized direction)
            transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime, Space.Self);

            // Optionally add a smoothing mechanism (incremental approach)
            rotationProgress += Time.deltaTime * rotationSpeed;
            if (rotationProgress >= 360f)
            {
                // Reset rotation once it completes a full 360-degree cycle
                rotationProgress = 0f;
                // Randomize the direction again after a full cycle for smoother effect
                rotationDirection = new Vector3(
                    Random.Range(-1f, 1f),  // Randomize rotation on X-axis
                    Random.Range(-1f, 1f),  // Randomize rotation on Y-axis
                    Random.Range(-1f, 1f)   // Randomize rotation on Z-axis
                ).normalized;

                Debug.Log("Cube started rotating in new direction: " + rotationDirection);
            }
        }
    }

    // This method will be called when the event is triggered
    void StartRotation()
    {
        isRotating = true;
        rotationProgress = 0f; // Reset rotation progress when starting rotation

        // Randomize the rotation direction (normalized for consistent speed)
        rotationDirection = new Vector3(
            Random.Range(-1f, 1f),  // Randomize rotation on X-axis
            Random.Range(-1f, 1f),  // Randomize rotation on Y-axis
            Random.Range(-1f, 1f)   // Randomize rotation on Z-axis
        ).normalized;

        Debug.Log("Cube started rotating in direction: " + rotationDirection);
    }
}
