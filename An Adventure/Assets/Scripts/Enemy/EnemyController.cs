using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth = 100;
    public Animator enemyAnimator;
    private bool isDead = false;

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        enemyAnimator.SetTrigger("Hit");

        if (enemyHealth <= 0)
        {
            enemyAnimator.SetTrigger("isDead");
            isDead = true;
        }
    }

    public void Die()
    {
        Debug.Log(name + " died");
        Destroy(gameObject);
    }

    public bool isEnemyDead()
    {
        return isDead;
    }
}
