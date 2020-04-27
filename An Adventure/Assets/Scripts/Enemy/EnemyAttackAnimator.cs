using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAnimator : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackCooldown = 1.5f;
    private bool playerInRange = false;

    float nextAttack;

    public Animator enemyAnimator;
    private PlayerHealth playerHealth = null;

    void Update()
    {
        if(Time.time > nextAttack && playerInRange)
        {
            enemyAnimator.SetTrigger("Attack");
            nextAttack = Time.time + attackCooldown;
        }
    }

    public void Attack()
    {
        if (playerHealth == null) return;

        playerHealth.TakeDamage(attackDamage);
        Debug.Log("Player hit by " + gameObject.name);
    }

    public bool isPlayerInRange()
    {
        return playerInRange;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
            playerHealth = other.GetComponent<PlayerHealth>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
            playerHealth = null;
        }
    }
}
