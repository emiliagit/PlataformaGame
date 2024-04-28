using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public abstract class EnemyPadre : MonoBehaviour
{
    public Slider healthSlider;
   
    protected float hp;

    private LifePlayer player;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecibirDanio()
    {
        hp -= 10;
        UpdateHealthUI();
        
    }

   

    public void UpdateHealthUI()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        healthSlider.value = hp;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(10);
        }
    }
}
