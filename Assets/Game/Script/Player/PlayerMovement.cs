using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;

    private float runSpeed = 7f;

    public float fuerzaSalto = 5f;
   
    private bool enSuelo;

    private int saltosRestantes = 2;

    public GameObject Bomba;

    public GameObject Explosion;

    //private Animator playerAnimator;

    void Start()
    {
        //playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //playerAnimator.SetBool("IsWalking", true);
           
            transform.localScale = new Vector3(1, 1, 1);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
                
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //playerAnimator.SetBool("IsWalking", true);
            
            transform.localScale = new Vector3(-1, 1, 1);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
                //playerAnimator.SetBool("IsRunning", true);
            }
        }
       

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
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
