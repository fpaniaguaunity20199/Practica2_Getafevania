﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedorSinRotacion : MonoBehaviour
{
    [SerializeField] Transform origen;
    [SerializeField] Transform destino;
    [SerializeField] float velocidad;
    [SerializeField] int direccion = 1;
    private SpriteRenderer sr;
    private float porcentaje = 0;
    void Update()
    {
        porcentaje += Time.deltaTime * velocidad * direccion;
        transform.position = 
            Vector2.Lerp(
                origen.position, 
                destino.position, 
                porcentaje);
        if (porcentaje >= 1 || porcentaje<=0)
        {
            direccion *= -1;
            porcentaje = Mathf.Clamp(porcentaje, 0, 1f);
        }
    }
}
