using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : EnemyPadre
{
    public Transform player; 
    public float detectionRange = 10f; // Rango de detección del jugador
    public GameObject bombPrefab; 
    public float bombForce = 10f; 
    public float fireRate = 1f; // Tasa de disparo (bombas por segundo)

    private float nextFireTime; // Tiempo en el que podrá disparar la siguiente bomba

    //public Slider slider;

    private void Start()
    {
        hp = 150;
        UpdateHealthUI();
    }

    void Update()
    {


        // Calculamos la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de detección y ha pasado el tiempo suficiente desde el último disparo
        if (distanceToPlayer <= detectionRange && Time.time >= nextFireTime)
        {
          
            Shoot();

            // Actualizamos el tiempo en el que podrá disparar la siguiente bomba
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
       
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);

        // Calculamos la dirección hacia la que lanzaremos la bomba (hacia el jugador)
        Vector3 shootDirection = (player.position - transform.position).normalized;

        // Aplicamos fuerza a la bomba en la dirección calculada
        bomb.GetComponent<Rigidbody>().AddForce(shootDirection * bombForce, ForceMode.Impulse);
    }

    void OnDrawGizmosSelected()
    {
        // Dibujamos un gizmo en la escena para representar el rango de detección del enemigo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
