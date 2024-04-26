using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public float attackSpeed = 2f;
   
    public Animator animator;

    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack() 
    {
       

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("IsAttacking", true);
           

        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

   
}
