using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public GameObject BombPrefab;
    public Transform BombSpawnPoint;
    public float BombSpeed = 13f;
    public float attackSpeed = 2f;
    private float nextAttackTime = 0f;

    //private Animator PlayerAnimator;

    private void Start()
    {
        //PlayerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAttackTime)
        {
            Shoot();
            nextAttackTime = Time.time + 1f / attackSpeed;

        }
    }

    private void Attack() 
    {
        if(Input.GetMouseButtonDown (0)) 
        {
            //PlayerAnimator.SetBool("IsAttacking", true);
        }
    }

    private void Shoot()
    {

        Vector3 shootDirection = BombSpawnPoint.forward;


        GameObject projectile = Instantiate(BombPrefab, BombSpawnPoint.position, Quaternion.LookRotation(shootDirection));
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.velocity = shootDirection * BombSpeed;
        Destroy(projectile, 3f);

    }
}
