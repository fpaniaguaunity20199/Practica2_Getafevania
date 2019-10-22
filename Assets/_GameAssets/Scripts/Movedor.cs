﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movedor : MonoBehaviour
{
    [SerializeField] Transform origen;
    [SerializeField] Transform destino;
    [SerializeField] float velocidad;
    [SerializeField] int direccion = 1;
    private SpriteRenderer sr;
    private float porcentaje = 0;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
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
            //transform.localScale = new Vector2(direccion, 1);
            sr.flipX = !sr.flipX;
        }
    }
}
