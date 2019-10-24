using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] float angularSpeed;
    [SerializeField] float timeToDestroy;
    [SerializeField] float danyo = 0.25f;
    private void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Comprobar si es enemigo mirando si tiene el Script Enemy
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().RecibirDanyo(danyo);
            Destroy(this.gameObject);
        }
    }
}
