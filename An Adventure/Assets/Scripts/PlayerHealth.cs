using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;
    public HealthBar health;

    private void Start()
    {
        health.setMaxHealth(playerHealth);
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        health.setHealth(playerHealth);

        if(playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!!!");
        Destroy(gameObject);
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
