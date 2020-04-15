using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public float Velocidad;
    public float puntoMuerte;

    private Vector3 movimiento = new Vector3(0, 0, 0);

    private void FixedUpdate()
    {
        movimiento = new Vector3(0, -(AudioSpectrum.amplitudeBuffer * Velocidad), 0);
        transform.Translate(movimiento);
    }

    private void Update()
    {
        if (transform.localPosition.y < puntoMuerte)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        if (transform.localPosition.y > -puntoMuerte)
        {
            gameObject.SetActive(false);
        }
    }
}
