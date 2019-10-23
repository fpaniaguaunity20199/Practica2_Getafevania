﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGold : MonoBehaviour
{
    [SerializeField] int puntuacion;
    private GameManager gm;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.IncrementarPuntuacion(puntuacion);
            Destroy(gameObject);
        }
    }
}
