using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed = 0.1f;
    public Vector3 jump;
    public Vector3 leftDash;
    public Vector3 rightDash;
    public float jumpForce = 2.0f;
    public float Force = 2.0f;
    public bool isGrounded;

    void Start()
    {   
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        leftDash = new Vector3(-2.0f, 0.0f, 0.0f);
        rightDash = new Vector3(2.0f, 0.0f, 0.0f);
    }

    void Update()
    {   
        Rigidbody rb = GetComponent<Rigidbody>();
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 displacement = new Vector3(horizontalAxis, 0, 0) * Time.deltaTime * PlayerSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        } else if (Input.GetKeyDown(KeyCode.LeftShift) && horizontalAxis<0)
        {
            rb.AddForce(leftDash * Force, ForceMode.Impulse);
        } else if (Input.GetKeyDown(KeyCode.LeftShift) && horizontalAxis > 0)
        {
            rb.AddForce(rightDash * Force, ForceMode.Impulse);
        } 

        rb.MovePosition(transform.position + displacement);
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}

