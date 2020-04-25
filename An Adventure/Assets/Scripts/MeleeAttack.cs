using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int meleeDamage = 20;

    bool inRange = false;
    GameObject enemy = null;
    private Animator characterGFX;
    public HealthBar cooldownBar;

    public float attackCooldown = 1f;
    private float nextAttack = 0f;

    void Start()
    {
        characterGFX = GetComponent<Animator>();
        cooldownBar.setMaxHealth(attackCooldown);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nextAttack <= Time.time)
        {
            characterGFX.SetTrigger("Slash");
            nextAttack = Time.time + attackCooldown;
            cooldownBar.setHealth(0f);
        }
        if (nextAttack >= Time.time)
        {
            cooldownBar.setHealth(attackCooldown - (nextAttack - Time.time));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            inRange = true;
            enemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            inRange = false;
            enemy = null;
        }
    }

    void Slash()
    {
        Debug.Log("Player is slashing.");
        if(inRange == true && enemy != null)
        {
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                Debug.Log("Player hit an enemy!!!");
                enemyController.TakeDamage(meleeDamage);
            }
        }
    }
}
