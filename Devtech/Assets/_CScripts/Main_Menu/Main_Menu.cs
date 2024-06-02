using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{

    public void Jogar()
    {
        SceneManager.LoadScene("MainHub");

    }

    public void Sair()
    {
        Application.Quit();

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");


    }
    
}
