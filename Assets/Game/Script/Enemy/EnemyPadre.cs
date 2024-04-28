using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public abstract class EnemyPadre : MonoBehaviour
{
    public Slider healthSlider;
   
    protected float hp;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecibirDanio()
    {
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            hp -= 10;
            UpdateHealthUI();
        }
        


    }

    public void UpdateHealthUI()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        healthSlider.value = hp;
       
    }
}
