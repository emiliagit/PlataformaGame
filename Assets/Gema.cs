using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gema : MonoBehaviour
{
    public ParticleSystem particle;
    /*public float destroyDelay = 3f;*/ // Tiempo en segundos antes de destruir el objeto

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          particle.Play();
            Destroy(gameObject/*, destroyDelay*/);
        }
    }

   
}
