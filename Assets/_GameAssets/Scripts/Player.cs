using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    private float x, y;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        if (Mathf.Abs(x) > 0)
        {
            rb.velocity = new Vector2(x * speed, 0);
        }
        
    }
}
