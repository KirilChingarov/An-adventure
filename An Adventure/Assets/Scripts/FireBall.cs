using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;
    public GameObject player;
    private Animator characterGFX;

    public float attackCooldown = 4f;
    private float nextAttack = 0f;

    void Start()
    {
        characterGFX = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && nextAttack <= Time.time && !player.GetComponent<PlayerMovement>().IsRotating())
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
