using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {
    
    public float VelocidadProyectil;
    public float puntoMuerte;

    private void FixedUpdate()
    {
        transform.Translate(0, VelocidadProyectil, 0);
    }

    private void Update()
    {
        if (transform.localPosition.y > puntoMuerte)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Balas")
        {
            ChoqueBalas.InsanciarVfx(transform.position);
            Destroy(other.gameObject);
            Destroy(transform.gameObject);
        }
    }

}
