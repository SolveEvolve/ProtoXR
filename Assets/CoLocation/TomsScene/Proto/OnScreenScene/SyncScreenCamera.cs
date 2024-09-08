using UnityEngine;

public class SyncScreenCamera : MonoBehaviour
{
    public Transform playerHead; // Reference to the VR headset (the player's head)
    public Transform screen; // Reference to the screen object in your scene
    public Vector3 worldOffset = new Vector3(0, 0, -100); // Offset for the second world

    void LateUpdate()
    {
        // Calculate the player's relative position to the screen
        Vector3 relativePos = playerHead.position - screen.position;

        // Apply the Z-axis offset to the second world
        transform.position = screen.position + relativePos + worldOffset;

        // Set the second world camera's rotation to match the player's head rotation
        transform.rotation = Quaternion.LookRotation(playerHead.forward, Vector3.up);
    }
}
