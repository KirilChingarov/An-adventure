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
    public int isGrounded = 1;
    public int dashCooldown = 3;
    public float dashSpeed = 2;
    private int rotated = 0;
    private float horizontalAxis;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.transform.Rotate(0, -90, 0, Space.Self);
        rotated--;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        leftDash = new Vector3(-2.0f, 0.0f, 0.0f);
        InvokeRepeating("DecreaseCooldown", 1.0f, 1.0f);
    }

    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 displacement = new Vector3(horizontalAxis, 0, 0) * Time.deltaTime * PlayerSpeed;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
        if (isGrounded > -1 && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded--;
            Jump();
        }

        rb.MovePosition(transform.position + displacement);
        Rotate();
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

    void Dash()
    {
        //rb.velocity = transform.forward * dashSpeed;
        if (horizontalAxis < 0 && dashCooldown == 0)
        {
            rightDash *= Time.deltaTime * dashSpeed;
            rb.MovePosition(transform.position + rightDash);
            dashCooldown = 3;
        }
        if (horizontalAxis > 0 && dashCooldown == 0)
        {
            leftDash *= Time.deltaTime * dashSpeed;
            rb.MovePosition(transform.position + leftDash);
            dashCooldown = 3;
        }
    }

    void Jump()
    { 
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
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

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.25f);
        rb.useGravity = true;
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
}

