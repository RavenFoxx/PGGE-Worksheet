using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public Transform playerT;
    public Transform cameraT;
    public void Update()
    {
        const float pHeight = 2.0f;
        Vector3 targetPos = playerT.position;
        targetPos.y += pHeight;
        cameraT.LookAt(targetPos);
    }
}
