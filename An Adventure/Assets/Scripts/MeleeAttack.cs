using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int meleeDamage = 20;

    bool inRange = false;
    GameObject enemy = null;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Slash(inRange, enemy);
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

    void Slash(bool inRagne, GameObject enemy)
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
