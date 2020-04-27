using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    public float playerSpeed = 0.1f;
    public float jumpForce = 2.0f;
    private int rotated = -1;
    public int isGrounded = 1;
    private bool rotating;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGrounded > -1 && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded--;
            Jump();
        }

        horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 displacement = new Vector3(horizontalAxis, 0, 0) * Time.deltaTime * playerSpeed;
        rb.MovePosition(transform.position + displacement);
        Rotate();
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
    }

    void Rotate()
    {
        if (!rotating)
        {
            if (Input.GetKey(KeyCode.A) && rotated < 0 && horizontalAxis < 0)
            {
                StartCoroutine(RotateMe(Vector3.up * 180, 0.05f));
                rotated = 1;
            }
            if (Input.GetKey(KeyCode.D) && rotated > 0 && horizontalAxis > 0)
            {
                StartCoroutine(RotateMe(Vector3.up * -180, 0.05f));
                rotated = -1;
            }
        }
    }

    IEnumerator RotateMe(Vector3 angles, float seconds)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + angles);
        rotating = true;
        for (var t = 0f; t < 1; t += Time.deltaTime / seconds)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.rotation = toAngle;
        rotating = false;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = 0;
        }
    }

    public bool IsRotating()
    {
        return rotating;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = 1;
        }
    }
}

