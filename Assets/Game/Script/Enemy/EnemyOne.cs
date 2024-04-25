using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyOne : EnemyPadre
{
    public float velocidad = 4f; // Velocidad de movimiento
    public float limiteIzquierdo = -4f; // Límite izquierdo
    public float limiteDerecho = 4f; // Límite derecho
    private bool moviendoDerecha = true; // Dirección inicial

    //public Slider slider;


    private void Start()
    {
        hp = 100;
        //UpdateHealthUI();
    }
    void Update()
    {
        EnemyMovement();

        UpdateHealthUI();
        RecibirDanio();
    }

    private void EnemyMovement()
    {
        // Mueve el objeto hacia la derecha o la izquierda según la dirección actual
        if (moviendoDerecha)
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }

        // Si alcanza uno de los límites, cambia la dirección
        if (transform.position.x >= limiteDerecho)
        {
            moviendoDerecha = false;
        }
        else if (transform.position.x <= limiteIzquierdo)
        {
            moviendoDerecha = true;
        }
    }
}
