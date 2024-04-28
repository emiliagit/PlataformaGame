using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : EnemyPadre
{
    private float velocidadMovimiento = 1.5f;
    private float distanciaMovimiento = 1.5f; 

    private Vector3 posicionInicial; 
    void Start()
    {
        hp = 100;

        posicionInicial = transform.position;
    }

    void Update()
    {
        GhostMovement();

        UpdateHealthUI();
        RecibirDanio();
    }

    private void GhostMovement()
    {
        // Calcula la posici�n a la que el fantasma debe moverse
        Vector3 posicionDestino = posicionInicial + Vector3.up * distanciaMovimiento * Mathf.Sin(Time.time * velocidadMovimiento);

        // Mueve al fantasma hacia la posici�n destino
        transform.position = Vector3.Lerp(transform.position, posicionDestino, Time.deltaTime);
    }
}