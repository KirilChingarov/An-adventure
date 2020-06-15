using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothness = 0.1f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.one;

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothness, Mathf.Infinity, Time.smoothDeltaTime);
        transform.position = smoothedPosition;
    }

}
