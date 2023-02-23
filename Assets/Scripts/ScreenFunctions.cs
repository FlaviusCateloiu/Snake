using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFunctions : MonoBehaviour
{
    public void game()
    {
        SceneManager.LoadScene("Snake");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void info()
    {
        SceneManager.LoadScene("Info");
    }

    public void pantallaPrincipal()
    {
        SceneManager.LoadScene("FirstScreen");
    }
}
