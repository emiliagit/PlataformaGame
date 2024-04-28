using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyPadre : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
   
    protected float hp;

    [SerializeField] private GameObject deathEnemy;
    [SerializeField] private Animator deathAnimator;


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
        if(hp <= 0)
        {
            //GameObject death = Instantiate(deathEnemy, transform.position, Quaternion.identity);
            deathAnimator.SetBool("enemyDeath", true);
            //Destroy(death, 1f);
            Destroy(gameObject);
        }
       

    }

    public void UpdateHealthUI()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        healthSlider.value = hp;
       
    }
}
