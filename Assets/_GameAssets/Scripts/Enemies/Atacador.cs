﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacador : MonoBehaviour
{
    [SerializeField] float fuerza;
    [Range(0,2)]
    [SerializeField] float danyo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,1) * fuerza);
            collision.gameObject.GetComponent<Player>().RecibirDanyo(danyo);
        }
    }
}
