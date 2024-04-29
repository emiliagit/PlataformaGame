using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
   
   
    public Animator animator;

    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
   
    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            animator.SetBool("IsAttacking", true);
            
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private void Attack() 
    {
        Collider[] objetos = Physics.OverlapSphere(controladorGolpe.position, radioGolpe);

        foreach (Collider colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent<EnemyPadre>().RecibirDanio();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }


}
