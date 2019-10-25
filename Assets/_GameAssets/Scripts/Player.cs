using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform puntoDisparo;
    [SerializeField] float fuerzaDisparo;
    [SerializeField] float jumpForce;
    [SerializeField] Transform puntoDeteccion;
    [SerializeField] LayerMask layerSuelo;
    [SerializeField] PhysicsMaterial2D pm2d;
    private AudioSource[] audios;
    private float x, y;
    private Rigidbody2D rb;
    private GameManager gm;
    private Animator animator;
    private const int AUDIO_SHOT = 0;
    private const int AUDIO_JUMP = 1;
    //private bool inFloor = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        audios = GetComponents<AudioSource>();
    }
    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (x > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (Mathf.Abs(x) < 0.5)
        {
            x = 0;
            rb.velocity = new Vector2(0, rb.velocity.y);
            //transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Saltar();
        }
    }
    void FixedUpdate()
    {
        if (Mathf.Abs(x) > 0)
        {
            animator.SetBool("walking", true);
            rb.velocity = new Vector2(x * speed, rb.velocity.y);
        } else
        {
            animator.SetBool("walking", false);
            //rb.velocity = new Vector2(0, 0);
        }
        
    }
    public void RecibirDanyo(float danyo)
    {
        gm.QuitarVida(danyo);
    }
    private void Disparar()
    {
        GameObject proyectil = Instantiate(
            prefabProyectil, 
            puntoDisparo.position, 
            puntoDisparo.rotation);
        proyectil.GetComponent<Rigidbody2D>().AddForce(puntoDisparo.right * fuerzaDisparo);
        audios[AUDIO_SHOT].Play();
    }
    private void Saltar()
    {
        if (InFloor())
        {
            //rb.AddForce(Vector2.up * jumpForce);//Alternativa mediante impulso
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            audios[AUDIO_JUMP].Play();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        InFloor();
    }
    private bool InFloor()
    {
        Collider2D c2d = Physics2D.OverlapBox(puntoDeteccion.position, new Vector2(0.605f, 0.1f), 0, layerSuelo);
        if (c2d != null)
        {
            GetComponent<CapsuleCollider2D>().sharedMaterial = null;
            return true;
        }
        GetComponent<CapsuleCollider2D>().sharedMaterial = pm2d;
        return false;
    }
}
