using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour {

    public enum Bandas {nave, altos, medios, bajos};
    public Bandas EQ;
    public float VelocidadBanda;
    public float PoderSin;
    [Range(0, 7)]
    public int Banda;
    public Vector3 offset;

    private Vector3 mover;
    private float Sin;

    private void Update()
    {
        Sin = Mathf.Sin(Time.time) * PoderSin;
        switch (EQ)
        {
            case Bandas.nave:
                mover = new Vector3(offset.x + Sin, offset.y, offset.z);
                transform.localPosition = mover;
                break;
            case Bandas.altos:
                mover = new Vector3(((AudioSpectrum.bandBuffer[Banda] * VelocidadBanda) + offset.x) + Sin, offset.y, offset.z);
                transform.localPosition = mover;
                break;
            case Bandas.medios:
                mover = new Vector3(((AudioSpectrum.bandBuffer[Banda] * VelocidadBanda) + offset.x) + Sin, offset.y, offset.z);
                transform.localPosition = mover;
                break;
            case Bandas.bajos:
                mover = new Vector3(((-AudioSpectrum.bandBuffer[Banda] * VelocidadBanda) + offset.x) + Sin, offset.y, offset.z);
                transform.localPosition = mover;
                break;
            default:
                break;
        }
    }
}