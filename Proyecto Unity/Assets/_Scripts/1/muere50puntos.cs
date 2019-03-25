using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muere50puntos : MonoBehaviour {

    public float tiempoMuerte;

    private void OnEnable()
    {
        StartCoroutine(Muerte());
    }

    IEnumerator Muerte()
    {
        yield return new WaitForSeconds(tiempoMuerte);
        Destroy(gameObject);
    }
}
