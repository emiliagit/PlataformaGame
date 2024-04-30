using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionDeVictoria : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject objectToSpawn;

    public ContadorGemas Contador;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndGame()
    {


        if (Contador.GetTotalGems() == 0)
        {

            Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
            //SpawnFIndeJuego spawnFinDeJuego = FindObjectOfType<SpawnFIndeJuego>();


            //spawnFinDeJuego.enabled = true;


        }
    }
}
