using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numeroVidasMaximo;
    [SerializeField] int numeroVidas;
    [SerializeField] float vidaMaxima = 1;
    [SerializeField] float vida;

    public int GetNumeroVidasMaximo()
    {
        return numeroVidasMaximo;
    }
    public void QuitarVida(float quita)
    {
        float resto;
        //Restamos la vida
        vida = vida - quita;
        resto = vida;
        if (vida <= 0)
        {
            GetComponent<UIManager>().ActualizarVida(numeroVidas, 0);
            numeroVidas = numeroVidas - 1;
            vida = vidaMaxima;
            if (numeroVidas <= 0)
            {
                //MUELTE - GAME OVER
                print("GameOver");
            } 
        }
        if (resto < 0)
        {
            QuitarVida(resto*-1);
        }
        GetComponent<UIManager>().ActualizarVida(numeroVidas, vida);
    }
}
