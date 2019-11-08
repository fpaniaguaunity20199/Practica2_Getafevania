using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDark : MonoBehaviour
{
    public float speed;
    float x, y;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {

        rb2d.velocity = new Vector2(x * Time.deltaTime * speed, rb2d.velocity.y);
    }
}
