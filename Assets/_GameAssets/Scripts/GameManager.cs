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
    
}
