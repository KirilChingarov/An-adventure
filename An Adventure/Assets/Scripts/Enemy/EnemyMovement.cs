using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public EnemyAggroRange aggroRange;
    public EnemyAttackAnimator attackRange;
    public Transform target;

    private Rigidbody rb;
    public GameObject enemyGFX;
    private Animator enemyAnimator;
    private EnemyController enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyAnimator = enemyGFX.GetComponent<Animator>();
        enemy = GetComponent<EnemyController>();
    }

    void Update()
    {
        if (!aggroRange.isTargetInRange() || enemy.isEnemyDead())
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
            enemyAnimator.SetFloat("EnemySpeed", 0f);
            return;
        }

        float direction = getDirection();

        rb.velocity = new Vector3(direction * speed, rb.velocity.y, rb.velocity.z);
        enemyAnimator.SetFloat("EnemySpeed", Mathf.Abs(direction));

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
            enemyGFX.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        if (rb.velocity.x <= -0.01f)
        {
            enemyGFX.transform.eulerAngles = new Vector3(0f, -90f, 0f);
        }
    }
}
