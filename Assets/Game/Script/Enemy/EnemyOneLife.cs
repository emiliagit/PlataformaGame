using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyOneLife : MonoBehaviour
{
    public Slider healthSlider;
    //public TextMeshProUGUI hpText;
    public float hp;


    private void Start()
    {
        hp = 100;
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthUI();
        RecibirDanio();
    }

    public void RecibirDanio()
    {
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            hp -= 10;
            UpdateHealthUI();
        }
        
    }

    void UpdateHealthUI()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        healthSlider.value = hp;
        //hpText.text = "LIfe: " + hp.ToString() + "%";
    }
}
