using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyOne : EnemyPadre
{
    public float speed = 5f; // Velocidad de movimiento
    public float distance = 5f; // Distancia que cubrir� en cada direcci�n

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingRight = true;




    private void Start()
    {
        hp = 100;
        startPosition = transform.position;
        SetTargetPosition();
    }
    void Update()
    {
        EnemyMovement();

        UpdateHealthUI();
        RecibirDanio();
    }

    private void EnemyMovement()
    {
        // Mover el objeto hacia la posici�n objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Si ha llegado a la posici�n objetivo, cambiar la direcci�n y la nueva posici�n objetivo
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            movingRight = !movingRight;
            SetTargetPosition();
        }
    }

    void SetTargetPosition()
    {
        if (movingRight)
            targetPosition = startPosition + Vector3.right * distance;
        else
            targetPosition = startPosition - Vector3.right * distance;
    }
}
