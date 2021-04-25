using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    public float smoothSpd = .125f;
    public Vector3 offset;

    private void Update() {
        lateCamera();
    }
    private void lateCamera()
    {
        Vector3 desiredPosition = transform.position;
        desiredPosition.y = (player.position + offset).y;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpd);
        transform.position = smoothedPosition;

    }
}
