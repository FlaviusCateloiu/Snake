using System;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    private static float puntos;
    private TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        puntos = 0;
        textMesh.text = puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
        textMesh.text = puntos.ToString("0");
    }

    public static String GetPuntos()
    {
        return puntos.ToString("0");
    }
}
