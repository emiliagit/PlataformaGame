using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] RawImage[] hearts;

    private int maxHealth = 4;
    private int currentHealth;

    private Ataque attack;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateLife(currentHealth);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // M�todo para que el jugador reciba da�o
    public void TakeDamage(int da�o)
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            UpdateLife(currentHealth);
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    public void UpdateLife(int hp)
    {


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < hp)
                hearts[i].gameObject.SetActive(true);
            else
                hearts[i].gameObject.SetActive(false);
        }

    }

    

}
