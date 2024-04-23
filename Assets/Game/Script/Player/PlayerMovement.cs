using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float velocidad = 5f;

    public float fuerzaSalto = 5f;
   
    private bool enSuelo;

    private int saltosRestantes = 2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
       
       
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, 0f) * velocidad * Time.deltaTime;

        
        transform.Translate(movimiento);

        if (Input.GetKeyDown(KeyCode.W) && enSuelo)
        {
            if (saltosRestantes > 0)
            {
                // Si está en el suelo o aún hay saltos restantes
                if (enSuelo || saltosRestantes == 2)
                {
                    // Aplicar fuerza de salto
                    GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
                    // Reducir los saltos restantes
                    saltosRestantes--;

                    // Si no estaba en el suelo, ya no puede realizar otro salto hasta que toque el suelo nuevamente
                    if (!enSuelo)
                        enSuelo = false;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si ha colisionado con el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            saltosRestantes = 2;
            enSuelo = true;
        }
    }
}
