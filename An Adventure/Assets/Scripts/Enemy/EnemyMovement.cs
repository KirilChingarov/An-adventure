using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public EnemyAggroRange aggroRange;
    public EnemyAttack attackRange;
    public Transform target;

    private Rigidbody rb;
    public GameObject enemyGFX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!aggroRange.isTargetInRange())
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
            return;
        }

        float direction = getDirection();

        rb.velocity = new Vector3(direction * speed, rb.velocity.y, rb.velocity.z);

        Flip();
    }

    private float getDirection()
    {
        if (attackRange.isPlayerInRange()) return 0f;

        if (target.position.x > gameObject.transform.position.x) return 1f;
        else return -1f;
    }

    private void Flip()
    {
        if (rb.velocity.x >= 0.01f)
        {
            enemyGFX.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (rb.velocity.x <= -0.01f)
        {
            enemyGFX.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}
