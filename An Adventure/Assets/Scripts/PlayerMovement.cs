using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 0.1f;
    public float jumpForce = 2.0f;
    public int dashCooldown = 3;
    public float dashSpeed = 2.0f;
    public float startDashTime;
    private int rotated = 0;
    public int isGrounded = 1;
    private float horizontalAxis;
    private Rigidbody rb;
    private int direction;
    private float dashTime;
    private bool dashed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.transform.Rotate(0, -90, 0, Space.Self);
        rotated--;
        InvokeRepeating("DecreaseCooldown", 1.0f, 1.0f);
        dashTime = startDashTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown == 0)
        {
            Dash();
        }
        if (isGrounded > -1 && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded--;
            Jump();
        }

        if (dashTime <= 0 && dashed)
        {
            if(direction != 3) 
            { 
                rb.velocity = Vector3.zero;
            } else
            {
                rb.velocity = Vector3.up * 1;
            }

            direction = 0;
            dashed = false;
        }
        else
        {
            dashTime -= Time.deltaTime;

            if (direction == 1)
            {
                rb.velocity = Vector3.left * dashSpeed;
            }
            else if (direction == 2)
            {
                rb.velocity = Vector3.right * dashSpeed;
            }
            else if (direction == 3)
            {
                rb.velocity = Vector3.up * dashSpeed;
            }
        }

        horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 displacement = new Vector3(horizontalAxis, 0, 0) * Time.deltaTime * playerSpeed;
        rb.MovePosition(transform.position + displacement);
        Rotate();
    }


    void Dash()
    {
        dashed = true;
        dashCooldown = 3;
        dashTime = startDashTime;

        if (Input.GetKey(KeyCode.W))
        {
            direction = 3;
        }
        if (horizontalAxis < 0)
        {
            direction = 1;
        }
        if (horizontalAxis > 0)
        {
            direction = 2;
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
    }

    void Rotate()
    {    
        if (Input.GetKey(KeyCode.A) && rotated < 0 && horizontalAxis < 0)
        {
            StartCoroutine(RotateMe(Vector3.up * 180, 0.05f));
            rotated = 1;
        }
        if(Input.GetKey(KeyCode.D) && rotated > 0 && horizontalAxis > 0) {
            StartCoroutine(RotateMe(Vector3.up * -180, 0.05f));
            rotated = -1;
        }
    }

    IEnumerator RotateMe(Vector3 angles, float seconds)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + angles);
        for (var t = 0f; t < 1; t += Time.deltaTime / seconds)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.rotation = toAngle;
    }

    void OnCollisionExit()
    {
        isGrounded = 0;
    }

    void OnCollisionStay()
    {
        isGrounded = 1;
    }

    void DecreaseCooldown()
    {
        if (dashCooldown > 0)
        {
            dashCooldown--;
        }
    }
}

