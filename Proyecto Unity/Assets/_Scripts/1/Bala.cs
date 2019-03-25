using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public float Velocidad;
    public float EsperaMuerte = 2;

    private Vector3 movimiento = new Vector3(0, 0, 0);

    private void OnEnable()
    {
        StartCoroutine(Muerte());
    }

    private void FixedUpdate()
    {
        movimiento = new Vector3(0, -(AudioSpectrum.amplitudeBuffer * Velocidad), 0);
        transform.Translate(movimiento);
    }

    private IEnumerator Muerte()
    {
        yield return new WaitForSeconds(EsperaMuerte);
        Destroy(gameObject);
    }
}
