using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Squeleton : EnemyPadre
{
    public float radio = 10f; // Radio de detección del jugador
    public float moveSpeed = 0.5f; // Velocidad de movimiento del enemigo
    
    //private Transform player; // Referencia al transform del jugador
    private bool playerDetectado = false; // Variable para controlar si el jugador ha sido detectado
    private Vector3 playerPosition;

    private Rigidbody Rb;

    public Animator squeletonAnimator;


    private void Start()
    {

        hp = 100;
        Rb = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca el transform del jugador
    }

    private void Update()
    {

        UpdateHealthUI();
        //RecibirDanio();

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
        if (!playerDetectado)
        {
            // Comprueba si el jugador está dentro del radio de detección
            if (Vector3.Distance(transform.position, player.position) <= radio)
            {
                Debug.Log("player detectado");
                playerDetectado = true; // Marca al jugador como detectado
                playerPosition = player.position; // Establece la posición del jugador como destino
            }
            
        }
        else
        {
            if(hp > 0 )
            {
                squeletonAnimator.SetBool("squeletonMooving", true);
                // Calcula la dirección hacia la que mirar
                Vector3 direction = (playerPosition - transform.position).normalized;


                //Quaternion newRotation = Quaternion.Euler(0f, 180f, 0f);
                //rb.MoveRotation(newRotation);

                // Mueve al enemigo hacia la posición del jugador
                transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                squeletonAnimator.SetBool("squeletonMooving", false);

            }


        }
    }







}
