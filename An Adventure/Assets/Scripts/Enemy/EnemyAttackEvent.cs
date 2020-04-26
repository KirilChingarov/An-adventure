using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEvent : MonoBehaviour
{
    public EnemyAttackAnimator enemyAttack;
    public EnemyController enemyController;

    public void Attack()
    {
        enemyAttack.Attack();
    }

    public void EnemyDeath()
    {
        enemyController.Die();
    }
}
