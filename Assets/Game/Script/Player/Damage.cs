using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //public GameObject explosionPrefab;

    public LifePlayer player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Instanciar el prefab de la animaci�n del power-up
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            //Debug.Log("da�o");
            //Destroy(explosionPrefab, 1f);

            player.TakeDamage(1);

            // Eliminar el objeto que colision� 
            Destroy(other.gameObject);

        }
    }
}
