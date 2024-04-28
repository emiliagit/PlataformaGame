using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Squeleton : EnemyPadre
{
    public float detectionRadius = 10f; // Radio de detección del jugador
    public float moveSpeed = 0.5f; // Velocidad de movimiento del enemigo
    
    private Transform player; // Referencia al transform del jugador
    private bool playerDetected = false; // Variable para controlar si el jugador ha sido detectado
    private Vector3 targetPosition;

    private Rigidbody rb;

    

    private void Start()
    {

        hp = 150;
        rb = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca el transform del jugador
    }

    private void Update()
    {

        UpdateHealthUI();
        RecibirDanio();

        MovEnemy();

        if (hp <= 0)
        {
            healthSlider.gameObject.SetActive(false);
            squeletonAnimator.SetBool("enemyDeath", true);

            Destroy(gameObject, 1f);
        }
    }

    private void MovEnemy()
    {
        if (!playerDetected)
        {
            // Comprueba si el jugador está dentro del radio de detección
            if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
            {
                Debug.Log("player detectado");
                playerDetected = true; // Marca al jugador como detectado
                targetPosition = player.position; // Establece la posición del jugador como destino
            }
            
        }
        else
        {
            // Calcula la dirección hacia la que mirar
            Vector3 direction = (targetPosition - transform.position).normalized;

          
            //Quaternion newRotation = Quaternion.Euler(0f, 180f, 0f);
            //rb.MoveRotation(newRotation);

            // Mueve al enemigo hacia la posición del jugador
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        }
    }







}
