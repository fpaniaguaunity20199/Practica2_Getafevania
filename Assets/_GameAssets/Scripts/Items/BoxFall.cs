using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFall : MonoBehaviour
{
    [SerializeField] float timeToFall;
    [SerializeField] float fallSpeed;
    private bool falling = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", timeToFall);
        }
    }
    
    private void Update()
    {
        if (falling) {
            transform.Translate(Vector2.down * Time.deltaTime * fallSpeed);
            if (GetComponent<SpriteRenderer>().isVisible == false)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Fall()
    {
        falling = true;
    }
    
    
}
