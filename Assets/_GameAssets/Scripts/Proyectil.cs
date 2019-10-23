using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] float angularSpeed;
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * angularSpeed);
    }
}
