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
    public int dashCooldown = 3;
    public int rotated = 0;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.transform.Rotate(0, -90, 0, Space.Self);
        rotated--;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        leftDash = new Vector3(-2.0f, 0.0f, 0.0f);
        InvokeRepeating("DecreaseCooldown", 1.0f, 1.0f);
    }

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 displacement = new Vector3(horizontalAxis, 0, 0) * Time.deltaTime * PlayerSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(rb);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash(horizontalAxis, rb);
        }

        Rotate(rb);
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

    void DecreaseCooldown()
    {
        if (dashCooldown > 0)
        {
            dashCooldown--;
        }
    }

    void Dash(float horizontalAxis, Rigidbody rb)
    {
        if (horizontalAxis < 0 && dashCooldown == 0)
        {
            rb.AddForce(leftDash * Force, ForceMode.Impulse);
            dashCooldown = 3;
        }
        if (horizontalAxis > 0 && dashCooldown == 0)
        {
            rb.AddForce(leftDash * -1 * Force, ForceMode.Impulse);
            dashCooldown = 3;
        }
    }

    void Jump(Rigidbody rb)
    {
        if (isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }

    void Rotate(Rigidbody rb)
    {
        if(Input.GetKeyDown(KeyCode.A) && rotated < 0)
        {
            rb.transform.Rotate(0, 180, 0, Space.Self);
            rotated += 2;
        }
        if (Input.GetKeyDown(KeyCode.D) && rotated > 0) { 
            rb.transform.Rotate(0, -180, 0, Space.Self);
            rotated -= 2;
        }
    }
}

