using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamanoCubo : MonoBehaviour {
    
    public float MultiplicadorEscala;
    [Range(0, 7)]
    public int Banda;
    public Vector3 offset;

    private void Update()
    {
        transform.localScale = new Vector3(1, AudioSpectrum.bandBuffer[Banda] * MultiplicadorEscala, 1);
    }
}
