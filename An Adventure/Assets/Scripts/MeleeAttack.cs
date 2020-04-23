using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int meleeDamage = 20;

    bool inRange = false;
    GameObject enemy = null;
    private Animator characterGFX;

    public float attackCooldown = 2f;
    private float nextAttack = 0f;

    void Start()
    {
        characterGFX = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && nextAttack <= Time.time)
        {
            characterGFX.SetTrigger("Slash");
            nextAttack = Time.time + attackCooldown;
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
