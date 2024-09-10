using UnityEngine;

public class SyncScreenCamera : MonoBehaviour
{
    public Camera sourceCamera; // Reference to the OVR camera (right eye anchor)
    public Camera targetCamera; // Reference to the second camera
    public Vector3 worldOffset = new Vector3(0, 0, -100); // Offset for the second world

    void LateUpdate()
    {
        // Sync position and rotation
        targetCamera.transform.position = sourceCamera.transform.position + worldOffset;
        targetCamera.transform.rotation = sourceCamera.transform.rotation;
        targetCamera.fieldOfView = sourceCamera.fieldOfView;
    }
}
