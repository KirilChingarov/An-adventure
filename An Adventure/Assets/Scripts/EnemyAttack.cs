using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectile;
    public int attackDamage = 10;
    public float attackCooldown = 1.0f;

    float nextAttack;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Character" && Time.time > nextAttack)
        {
            nextAttack = Time.time + attackCooldown;
            PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();

            if (playerHealth != null) {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Player Hit");
            }
        }
    }
}
