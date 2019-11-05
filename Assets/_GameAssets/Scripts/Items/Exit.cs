using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameManager.HasItem(ItemNames.BLUE_KEY))
            {
                print("VAMOOOOOS");
            }
            else
            {
                print("TE HACE FALTA LA LLAVE");
            }
        }
    }
    
}
