using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform target; // El objeto que la cámara seguirá (el jugador en este caso)
    public float smoothSpeed = 0.125f; // La velocidad de suavizado de la cámara

    private Vector3 offset; // La distancia entre la cámara y el jugador al inicio

    void Start()
    {
        // Calculamos el offset inicial
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Calculamos la posición objetivo hacia la que la cámara se moverá
        Vector3 desiredPosition = target.position + offset;

        // Suavizamos la transición hacia la posición objetivo
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizamos la posición de la cámara
        transform.position = smoothedPosition;
    }
}
