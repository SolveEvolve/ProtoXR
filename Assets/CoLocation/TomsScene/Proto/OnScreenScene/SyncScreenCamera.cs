using UnityEngine;

public class SyncScreenCamera : MonoBehaviour
{
    // Reference to the right eye camera from the OVR rig (room 1)
    public Camera cameraSource;

    // Reference to the second camera in room 2 (room at z = -100)
    public Camera cameraTarget;

    // Offset between room 1 and room 2 (this is -100 on the Z-axis)
    public Vector3 roomOffset = new Vector3(0, 0, -100);

    public bool syncFieldOfView = true;

    void Update()
    {
        // Apply the offset to the camera's position
        cameraTarget.transform.position = cameraSource.transform.position + roomOffset;

        // Copy rotation and field of view from the source camera
        cameraTarget.transform.rotation = cameraSource.transform.rotation;

        if (syncFieldOfView)
        {
            cameraTarget.fieldOfView = cameraSource.fieldOfView;
            cameraTarget.aspect = cameraSource.aspect;
        }

    }
}
