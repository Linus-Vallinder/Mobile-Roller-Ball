using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    [Space]
    public Vector3 cameraOffset;

    [Space]
    public float followSpeed;

    private void Update()
    {
        UpdateCamera();
    }

    private void UpdateCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed) + cameraOffset;
    }
}
