using UnityEngine;

public class SyncScreenCamera : MonoBehaviour
{
    public Camera mainCamera; // Reference to the OVR camera (right eye anchor)
    public Camera secondWorldCamera; // Reference to the second camera
    public Vector3 worldOffset = new Vector3(0, 0, -100); // Offset for the second world

    void LateUpdate()
    {
        // Sync position and rotation
        secondWorldCamera.transform.position = mainCamera.transform.position + worldOffset;
        secondWorldCamera.transform.rotation = mainCamera.transform.rotation;
    }
}
