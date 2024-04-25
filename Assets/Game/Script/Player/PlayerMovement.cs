using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
   
    private bool grounded;
    private int saltosRestantes = 2;
    public float fuerzaSalto = 5f;

    private Rigidbody rb;
    public float gravityMultiplier;

    private BoxCollider boxCollider;

    //private bool isMooving = false;

    public Animator animator;

   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        GravityCompensation();

        
    }

    private void Movimiento()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);


        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.Euler(0f, moveHorizontal > 0 ? 0f : 180f, 0f);
            rb.MoveRotation(newRotation);
        }


        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            animator.SetBool("ISjumping", true);
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
        else
        {
            animator.SetBool("ISjumping", false);
        }


        {
            if (movement != Vector3.zero)
            {
                animator.SetBool("ISmooving", true);
            }
            else
            {
                animator.SetBool("ISmooving", false);
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





    //if (Input.GetKey(KeyCode.D))
    //{
    //    {
    //        transform.Translate(Vector3.right * speed * Time.deltaTime);


    //        transform.localScale = new Vector3(1, 1, 1);
    //        if (Input.GetKey(KeyCode.LeftShift))
    //        {
    //            transform.Translate(Vector3.right * runSpeed * Time.deltaTime);

    //        }
    //    }
    //}

    //if (Input.GetKey(KeyCode.A))
    //{
    //    {
    //        transform.Translate(Vector3.left * speed * Time.deltaTime);


    //        transform.localScale = new Vector3(-1, 1, 1);
    //        if (Input.GetKey(KeyCode.LeftShift))
    //        {
    //            transform.Translate(Vector3.left * runSpeed * Time.deltaTime);

    //        }
    //    }
    //}
}
