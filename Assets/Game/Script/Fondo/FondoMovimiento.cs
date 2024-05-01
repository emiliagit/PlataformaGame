using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{

    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;

    private Material material;

    //private Transform playerTransform;

    private Rigidbody jugadorRB;



    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;

      jugadorRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        //playerTransform = playerObject.transform;
        //Debug.Log("Player found");
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        offset = (jugadorRB.velocity * 0.1f) * velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }


}
