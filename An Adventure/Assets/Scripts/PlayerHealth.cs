using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar health;

    public void TakeDamage(int damage)
    {
        GameStateController.Instance.health -= damage;
        health.setHealth(GameStateController.Instance.playerHealth);

        if (GameStateController.Instance.playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameStateController.Instance.OnDie();
        Destroy(gameObject);
    }
}
