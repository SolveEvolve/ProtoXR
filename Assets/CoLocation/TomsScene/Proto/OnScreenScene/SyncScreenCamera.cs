using UnityEngine;

public class SyncScreenCamera : MonoBehaviour
{
    // Reference to the right eye camera from the OVR rig (room 1)
    public Camera cameraSource;

    // Reference to the second camera in room 2 (room at z = -100)
    public Camera cameraTarget;

    // Offset between room 1 and room 2 (this is -100 on the Z-axis)
    public Vector3 roomOffset = new Vector3(0, 0, -100);

    void Update()
    {
        cameraTarget.transform.position = cameraSource.transform.position;
        cameraTarget.transform.rotation = cameraSource.transform.rotation;
        cameraTarget.fieldOfView = cameraSource.fieldOfView;
    }
}
