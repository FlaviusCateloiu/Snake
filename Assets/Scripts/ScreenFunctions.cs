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
        Debug.Log("El juego se esta cerrando.");
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
