using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPorBanda : MonoBehaviour {

    [Range(0, 7)]
    public int Banda;
    [Range(0,5)]
    public float limite = 3;
    public GameObject bala;
    public Transform lugarDisparo;
    [Space]
    public float tiempoEntreDisparos;
    public Transform PadreBalas;

    private float tiempoAnterior;
    private bool puedeDisparar;
    private Quaternion rotacionZero = Quaternion.identity;
    [Space]
    public bool muerto = false;

    private void Awake()
    {
        tiempoAnterior = tiempoEntreDisparos;
    }

    private void FixedUpdate()
    {
        if (AudioSpectrum.bandBuffer[Banda] > limite)
        {
            if (puedeDisparar)
            {
                if (!muerto)
                {
                    Disparar();
                }
            }
        }

        if (tiempoEntreDisparos > 0)
        {
            tiempoEntreDisparos -= Time.fixedDeltaTime;
            puedeDisparar = false;
        }
        if (tiempoEntreDisparos <= 0)
        {
            tiempoEntreDisparos = tiempoAnterior;
            puedeDisparar = true;
        }
    }

    private void Disparar()
    {
        Instantiate(bala, lugarDisparo.position, rotacionZero, PadreBalas);
    }
}
