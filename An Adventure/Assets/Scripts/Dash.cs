using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Player
{
    public int dashCooldown = 3;
    public float dashSpeed = 2.0f;
    public float startDashTime;
    private int direction;
    private float dashTime;
    private bool dashed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("DecreaseCooldown", 1.0f, 1.0f);
        dashTime = startDashTime;
    }

    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown == 0)
        {
            setDirection();
        }

        if (dashTime <= 0 && dashed)
        {
            removeVelocity();
        }
        else
        {
            addVelocity();
        }
    }
    
    void setDirection()
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
    
    void addVelocity()
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

    void removeVelocity()
    {
        rb.velocity = Vector3.zero;
        if (direction == 3)
        {
            rb.velocity = Vector3.zero;
        }

        direction = 0;
        dashed = false;
    }

    void DecreaseCooldown()
    {
        if (dashCooldown > 0)
        {
            dashCooldown--;
        }
    }
}
