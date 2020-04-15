using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPorBanda : MonoBehaviour
{

    [Range(0, 7)]
    public int Banda;
    [Range(0,5)]
    public float limite = 3;
    //public GameObject bala;
    public Transform lugarDisparo;
    [Space]
    public float tiempoEntreDisparos;
    public Transform PadreBalas;

    private float tiempoAnterior;
    private bool puedeDisparar;
    //private Quaternion rotacionZero = Quaternion.identity;
    [Space]
    public bool muerto = false;

    private MovimientoEnemigos mEnemigo;

    private void Awake()
    {
        tiempoAnterior = tiempoEntreDisparos;
        mEnemigo = GetComponent<MovimientoEnemigos>();
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
        //Instantiate(bala, lugarDisparo.position, rotacionZero, PadreBalas);
        switch (mEnemigo.EQ)
        {
            case MovimientoEnemigos.Bandas.nave:
                break;
            case MovimientoEnemigos.Bandas.altos:
                PoolActivos.Pool.I_BalaEnemigo(lugarDisparo.position, PoolActivos.TipoBala.altos);
                break;
            case MovimientoEnemigos.Bandas.medios:
                PoolActivos.Pool.I_BalaEnemigo(lugarDisparo.position, PoolActivos.TipoBala.medios);
                break;
            case MovimientoEnemigos.Bandas.bajos:
                PoolActivos.Pool.I_BalaEnemigo(lugarDisparo.position, PoolActivos.TipoBala.bajos);
                break;
            default:
                break;
        }
    }
}
