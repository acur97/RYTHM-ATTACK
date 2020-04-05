using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour {

    public enum Bandas {altos, medios, bajos};
    public Bandas EQ;
    public float VelocidadBanda;
    public float PoderSin;
    [Range(0, 7)]
    public int Banda;
    public Vector3 offset;

    private Vector3 mover;
    private float Sin;

    public void FixedUpdate()
    {
        Sin = Mathf.Sin(Time.time) * PoderSin;
        if (EQ == Bandas.altos)
        {
            mover = new Vector3(((AudioSpectrum.bandBuffer[Banda] * VelocidadBanda) + offset.x) + Sin, offset.y, offset.z);
        }
        if (EQ == Bandas.medios)
        {
            mover = new Vector3((((AudioSpectrum.bandBuffer[Banda] * VelocidadBanda) - 4f) + offset.x) + Sin, offset.y, offset.z);
        }
        if (EQ == Bandas.bajos)
        {
            mover = new Vector3(((-AudioSpectrum.bandBuffer[Banda] * VelocidadBanda) + offset.x) + Sin, offset.y, offset.z);
        }
    }

    private void Update()
    {
        if (EQ == Bandas.altos)
        {
            transform.localPosition = mover;
        }
        if (EQ == Bandas.medios)
        {
            transform.localPosition = mover;
        }
        if (EQ == Bandas.bajos)
        {
            transform.localPosition = mover;
        }
    }
}