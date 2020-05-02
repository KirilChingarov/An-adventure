using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Player
{
    public float dashCooldown = 3;
    public float dashSpeed = 2.0f;
    public float startDashTime;
    private int direction;
    private float dashTime;
    private bool dashed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("DecreaseCooldown", 1.0f, 0.01f);
        dashTime = startDashTime;
    }

    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0)
        {
            SetDirection();
        }

        if (dashTime <= 0 && dashed)
        {
            RemoveVelocity();
        }
        else
        {
            AddVelocity();
        }
    }
    
    void SetDirection()
    {
        dashed = true;
        dashCooldown = 3;
        dashTime = startDashTime;

        if (Input.GetKey(KeyCode.W))
        {
            direction = 3;
        }
        else if (horizontalAxis < 0)
        {
            direction = 1;
        }
        else if (horizontalAxis > 0)
        {
            direction = 2;
        }
    }
    
    void AddVelocity()
    {
        dashTime -= Time.deltaTime;
        
        switch (direction)
        {
            case 1:
                rb.velocity = Vector3.left * dashSpeed;
                break;
            case 2:
                rb.velocity = Vector3.right * dashSpeed;
                break;
            case 3:
                rb.velocity = Vector3.up * dashSpeed;
                break;
        }
    }

    void RemoveVelocity()
    {
        rb.velocity = Vector3.zero;
        
        if (direction == 3)
        {
            rb.AddForce(new Vector3(0.0f, 5.0f, 0.0f), ForceMode.Impulse);
        }

        direction = 0;
        dashed = false;
    }

    void DecreaseCooldown()
    {
        if (dashCooldown > 0)
        {
            dashCooldown-=0.01f;
        }
    }
}
