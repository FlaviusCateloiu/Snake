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

    public void buttonLeft()
    {
        Snake._direction = Rotate(Snake._direction, 90);
    }

    public void buttonRight()
    {
        Snake._direction = Rotate(Snake._direction, -90);
    }
    
    private Vector2 Rotate(Vector2 v, float degrees) {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}
