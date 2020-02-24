﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed = 0.1f;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    void Start()
    {   
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {   
        Rigidbody rb = GetComponent<Rigidbody>();
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 displacement = new Vector3(horizontalAxis, 0, 0) * Time.deltaTime * PlayerSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        
        rb.MovePosition(transform.position + displacement);
    }
    
    void OnCollisionStay()
    {
        isGrounded = true;
    }
}

