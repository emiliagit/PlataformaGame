using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    private float runSpeed = 7f;

    private bool grounded;

    private int saltosRestantes = 2;
    public float fuerzaSalto = 5f;

    private Rigidbody rb;
    public float gravityMultiplier;

    private CapsuleCollider capsuleCollider;

   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        GravityCompensation();

        
    }

    private void Movimiento()
    {

        if (Input.GetKey(KeyCode.D))
        {
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                

                transform.localScale = new Vector3(1, 1, 1);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector3.right * runSpeed * Time.deltaTime);

                }
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
               

                transform.localScale = new Vector3(-1, 1, 1);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
                    
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            if (saltosRestantes > 0)
            {
                // Si está en el suelo o aún hay saltos restantes
                if (grounded || saltosRestantes == 2)
                {
                    // Aplicar fuerza de salto
                    GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
                    // Reducir los saltos restantes
                    saltosRestantes--;

                    // Si no estaba en el suelo, ya no puede realizar otro salto hasta que toque el suelo nuevamente
                    if (!grounded)
                        grounded = false;
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
            grounded = true;
        }
    }


    private void GravityCompensation()
    {
        if (!grounded)
            rb.AddForce(Vector3.down * gravityMultiplier, ForceMode.Force);
    }
}
