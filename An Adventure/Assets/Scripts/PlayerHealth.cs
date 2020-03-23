using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        if(playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!!!");
        Destroy(gameObject);
    }
}
