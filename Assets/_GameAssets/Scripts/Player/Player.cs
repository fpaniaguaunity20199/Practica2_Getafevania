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
    [Header("Time to get player control after damage")]
    [SerializeField] float timeToRestoreControl;
    [SerializeField] FixedJoystick fixedJoystick;

    private AudioSource[] audios;
    private float x, y;
    private Rigidbody2D rb;
    private GameManager gm;
    private Animator animator;
    private const int AUDIO_SHOT = 0;
    private const int AUDIO_JUMP = 1;
    private Vector2 posInicial;
    private bool controlEnabled = true;
    private float controlOffset = 0.1f;//Valor a partir del cual se considera que está haciendo movimiento

    void Start()
    {
        posInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        audios = GetComponents<AudioSource>();
        IniciarPosicion();
    }
    private void Update()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                x = fixedJoystick.Horizontal;
                y = fixedJoystick.Vertical;
                break;
            case RuntimePlatform.WindowsEditor:
                x = Input.GetAxis("Horizontal");
                y = Input.GetAxis("Vertical");
                if (Input.GetButtonDown("Fire1"))
                {
                    Disparar();
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    Saltar();
                }
                break;
            case RuntimePlatform.WindowsPlayer:
                x = Input.GetAxis("Horizontal");
                y = Input.GetAxis("Vertical");
                if (Input.GetButtonDown("Fire1"))
                {
                    Disparar();
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    Saltar();
                }
                break;
        }

    }
    void FixedUpdate()
    {
        //Si no tenemos el control, nos salimos
        if (!controlEnabled)
        {
            return;
        }
        if (Mathf.Abs(x) > controlOffset)
        {
            animator.SetBool("walking", true);
            rb.velocity = new Vector2(x * speed, rb.velocity.y);
        } else
        {
            animator.SetBool("walking", false);
        }
        if (x > controlOffset)
        {
            transform.localScale = new Vector2(1,1);
        } else if (x < -controlOffset)
        {
            transform.localScale = new Vector2(-1,1);
        }
    }
    public void RecibirDanyo(float danyo)
    {
        if (gm.QuitarVida(danyo))
        {
            //Ha perdido todas las vidas
            gm.ResetGame();
            rb.velocity = Vector2.zero;
            IniciarPosicion();
        }
    }
    public void Disparar()
    {
        GameObject proyectil = Instantiate(
            prefabProyectil, 
            puntoDisparo.position, 
            puntoDisparo.rotation);
        Vector2 direction = new Vector2(transform.localScale.x, 0.45f);
        proyectil.GetComponent<Rigidbody2D>().AddForce(direction * fuerzaDisparo);
        audios[AUDIO_SHOT].Play();
    }
    public void Saltar()
    {
        if (InFloor())
        {
            //rb.AddForce(Vector2.up * jumpForce);//Alternativa mediante impulso
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            audios[AUDIO_JUMP].Play();
        }
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
    private void IniciarPosicion()
    {
        transform.position = gm.GetStoredPlayerPosition(posInicial);
    }
    public void DisableControl()
    {
        controlEnabled = false;
        Invoke("EnableControl", timeToRestoreControl);
    }
    private void EnableControl()
    {
        controlEnabled = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        InFloor();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Adhesivo"))
        {
            transform.SetParent(collision.gameObject.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Adhesivo"))
        {
            transform.SetParent(null);
        }
    }
}
