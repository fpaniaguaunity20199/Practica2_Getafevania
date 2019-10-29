using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosDolorosos : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float danyo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(-collision.gameObject.transform.localScale.x, 1) * force);
            collision.gameObject.GetComponent<Player>().RecibirDanyo(danyo);
            collision.gameObject.GetComponent<Player>().DisableControl();
        }
    }
}
