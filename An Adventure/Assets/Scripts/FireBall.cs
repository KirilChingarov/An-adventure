using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;
    private Animator characterGFX;

    public float attackCooldown = 4f;
    private float nextAttack = 0f;

    void Start()
    {
        characterGFX = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && nextAttack <= Time.time)
        {
            characterGFX.SetTrigger("Fireball");
            nextAttack = Time.time + attackCooldown;
        }
    }

    void Shoot()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
}
