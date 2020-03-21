using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public float fireBallSpeed = 1.0f;
    public Rigidbody rb;

    void Update()
    {
        rb.velocity = transform.forward * fireBallSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
