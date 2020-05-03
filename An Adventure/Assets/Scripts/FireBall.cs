using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;
    private Animator characterGFX;
    public HealthBar cooldownBar;
    public GameObject player;

    public float attackCooldown = 4f;
    private float nextAttack = 0f;

    void Start()
    {

        characterGFX = GetComponent<Animator>();
        cooldownBar.setMaxHealth(attackCooldown);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && nextAttack <= Time.time && !player.GetComponent<PlayerMovement>().IsRotating())
        {
            characterGFX.SetTrigger("Fireball");
            nextAttack = Time.time + attackCooldown;
            cooldownBar.setHealth(0f);
        }
        if (nextAttack >= Time.time)
        {
            cooldownBar.setHealth(attackCooldown - (nextAttack - Time.time));
        }
    }

    void Shoot()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }

    void freezePosition()
    {
        player.GetComponent<PlayerMovement>().FreezeMovement();
    }

    void unfreezePosition()
    {
        player.GetComponent<PlayerMovement>().RenewMovement();
    }
}
