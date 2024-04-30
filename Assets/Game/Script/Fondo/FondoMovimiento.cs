using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{

    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;

    private Material material;

    private Transform playerTransform;



    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        playerTransform = playerObject.transform;
        Debug.Log("Player found");
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        offset = (playerTransform.position.x * 0.1f) * velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }


}
