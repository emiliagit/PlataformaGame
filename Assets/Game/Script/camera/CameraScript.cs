using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform target; // El objeto que la c�mara seguir� (el jugador en este caso)
    public float smoothSpeed = 0.125f; // La velocidad de suavizado de la c�mara

    private Vector3 offset; // La distancia entre la c�mara y el jugador al inicio

    void Start()
    {
        // Calculamos el offset inicial
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Calculamos la posici�n objetivo hacia la que la c�mara se mover�
        Vector3 desiredPosition = target.position + offset;

        // Suavizamos la transici�n hacia la posici�n objetivo
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizamos la posici�n de la c�mara
        transform.position = smoothedPosition;
    }
}
