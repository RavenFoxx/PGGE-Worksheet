using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform cameraT;
    public Transform playerT;

    public void Update()
    {
        // Now we calculate the camera transformed axes.
        // We do this because our camera's rotation might have changed
        // in the derived class Update implementations. Calculate the new
        // forward, up and right vectors for the camera.
        Vector3 forward = cameraT.rotation * Vector3.forward;
        Vector3 right = cameraT.rotation * Vector3.right;
        Vector3 up = cameraT.rotation * Vector3.up;
        // We then calculate the offset in the camera's coordinate frame.
        // For this we first calculate the targetPos 
        Vector3 targetPos = playerT.position;
        // Add the camera offset to the target position.
        // Note that we cannot just add the offset.
        // You will need to take care of the direction as well.
        //Vector3 desiredPosition = targetPos + forward * GameConstants.CameraPositionOffset.z + right * GameConstants.CameraPositionOffset.x + up * GameConstants.CameraPositionOffset.y;
        // Finally, we change the position of the camera,
        // not directly, but by applying Lerp.
        //Vector3 position = Vector3.Lerp(cameraT.position, desiredPosition, Time.deltaTime * GameConstants.Damping);
        //cameraT.position = position;
    }
}
