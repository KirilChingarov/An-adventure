using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackCooldown = 1.5f;
    private bool playerInRange = false;

    float nextAttack;

    public bool isPlayerInRange()
    {
        return playerInRange;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Time.time > nextAttack)
        {
            playerInRange = true;
            nextAttack = Time.time + attackCooldown;
            PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

            if (playerHealth != null) {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Player Hit");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
