using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public float fireBallSpeed = 1.0f;
    public int fireBallDamage = 50;
    public Rigidbody rb;

    void Update()
    {
        rb.velocity = transform.forward * fireBallSpeed;
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log(hitInfo.name);

        EnemyController enemy = hitInfo.GetComponent<EnemyController>();
        if(enemy != null)
        {
            enemy.TakeDamgae(fireBallDamage);
        }
        
        Destroy(gameObject);
    }
}
