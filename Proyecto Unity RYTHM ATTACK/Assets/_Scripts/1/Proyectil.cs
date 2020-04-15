using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float VelocidadProyectil;
    public float puntoMuerte;

    private readonly string balas = "Balas";

    private void FixedUpdate()
    {
        transform.Translate(0, VelocidadProyectil, 0);
    }

    private void Update()
    {
        if (transform.localPosition.y > puntoMuerte)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        if (transform.localPosition.y < -puntoMuerte)
        {
            gameObject.SetActive(false);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(balas))
        {
            //ChoqueBalas.InsanciarVfx(transform.position);
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            PoolActivos.Pool.I_VFXchoqueEntreBalas(other.transform.position);
            //Destroy(other.gameObject);
            //Destroy(transform.gameObject);
        }
    }
}