using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muere50puntos : MonoBehaviour {

    public float tiempoMuerte;
    private float tiempo = 1;

    private void FixedUpdate()
    {
        tiempo -= tiempoMuerte;
        if (tiempo <= 0)
        {
            Destroy(gameObject);
        }
    }
}
