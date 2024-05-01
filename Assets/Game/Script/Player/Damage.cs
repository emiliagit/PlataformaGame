using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Gema")) 
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(explosionPrefab, 1f);

            Destroy(collision.gameObject);
        }
    }


}
