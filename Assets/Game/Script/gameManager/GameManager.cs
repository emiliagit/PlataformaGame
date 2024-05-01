using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject tutorialCanvas;
    public GameObject MainMenuCanvas;

    //private bool tutorialActive = false;



    public void PlayButton()
    {
        tutorialCanvas.SetActive(true);
        //tutorialActive = true;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("GameScene");

    }


    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ContinuarButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
