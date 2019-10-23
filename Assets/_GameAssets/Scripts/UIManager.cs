using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject panelVidas;
    [SerializeField] GameObject prefabCorazon;
    private GameManager gm;
    void Start()
    {
        gm = GetComponent<GameManager>();
        int numeroVidas = gm.GetNumeroVidasMaximo();
        for(int i = 0; i < numeroVidas; i++)
        {
            Instantiate(prefabCorazon, panelVidas.transform);
        }
    }
    public void ActualizarVida(int numeroVidasActuales, float vidaActual)
    {
        GameObject[] corazones = GameObject.FindGameObjectsWithTag("Corazon");
        GameObject ultimoCorazon = corazones[numeroVidasActuales-1];
        Image imagenUltimoCorazon = ultimoCorazon.GetComponent<Image>();
        imagenUltimoCorazon.fillAmount=vidaActual;
    }
}
