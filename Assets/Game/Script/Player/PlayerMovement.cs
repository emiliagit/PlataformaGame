using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public Animator animator;

    public ContadorGemas Contador;

    //[SerializeField] private ParticleSystem stepParticles;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

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

                // Si est� en el suelo o a�n hay saltos restantes
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



        if (movement != Vector3.zero)
        {
            animator.SetBool("ISmooving", true);
        }
        else
        {
            animator.SetBool("ISmooving", false);
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
        if (collision.gameObject.CompareTag("Gema"))
        {

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            if (Contador.GetTotalGems() == 0)
            {
                SceneManager.LoadScene("Victory");
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.CompareTag("Plano"))
        {
            Debug.Log("colision plano");
            SceneManager.LoadScene("GameOver");
        }

    }


}
