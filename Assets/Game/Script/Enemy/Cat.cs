using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Cat : EnemyPadre
{
    private Rigidbody rb;

    public float detectionRadius = 10f; 
    
    private Transform player; 
    private bool playerDetected = false; 

    private Vector3 targetPosition;

    public float velocidad = 2f;

    public Animator catAnimator;


    private void Start()
    {
        hp = 50;

        rb = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        UpdateHealthUI();
        //RecibirDanio();

        EnemyMovement();

        if (hp <= 0)
        {
            healthSlider.gameObject.SetActive(false);
            catAnimator.SetBool("enemyDeath", true);

            Destroy(gameObject, 1f);
        }

    }

    private void EnemyMovement()
    {
        if (!playerDetected)
        {
            // Comprueba si el jugador está dentro del radio de detección
            if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
            {
                Debug.Log("player detectado");
                playerDetected = true; // Marca al jugador como detectado
               
            }

        }
        else
        {
            if (hp > 0) 
            {
                catAnimator.SetBool("catMooving", true);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocidad * Time.deltaTime);

            }
            else
            {
                catAnimator.SetBool("catMooving", false);

            }
        }
        
    }

   
}
