using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    public float playerSpeed = 0.1f;
    public float jumpForce = 2.0f;
    private int rotated = -1;
    public int jumps = 2;
    public Animator animator;
    private bool rotating;
    private bool moving;

    void Start()
    { 
        rb = GetComponent<Rigidbody>();

        if (GameStateController.Instance.loaded)
        {
            GameStateController.Instance.loaded = false;
            gameObject.transform.position = new Vector3(GameStateController.Instance.playerPosition[0],
                GameStateController.Instance.playerPosition[1],
                GameStateController.Instance.playerPosition[2]);
        }
    }

    void Update()
    {
        if (jumps < 2 && Input.GetKeyDown(KeyCode.Space))
        {
            if (jumps == 1)
            {
                animator.SetTrigger("doubleJump");
            }
            Jump();
            jumps++;
            Debug.Log(jumps);
        }

        if (!moving)
        {
            horizontalAxis = Input.GetAxis("Horizontal");
            Vector3 displacement = new Vector3(horizontalAxis, 0, 0) * Time.deltaTime * playerSpeed;
            rb.MovePosition(transform.position + displacement);
            animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalAxis));
        }
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
            animator.SetTrigger("isAirborn");
        }
    }

    public bool IsRotating()
    {
        return rotating;
    }

    public void FreezeMovement()
    {
        animator.SetFloat("PlayerSpeed", 0);
        moving = true;
    }

    public void RenewMovement()
    {
        moving = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            animator.SetTrigger("landed");
            jumps = 0;
        }
    }

}

