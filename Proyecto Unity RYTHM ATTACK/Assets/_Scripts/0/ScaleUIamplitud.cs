using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleUIamplitud : MonoBehaviour {

    public float escalaInicial = 0.9f;
    public float multiplicador = 0.025f;
    [Range(0, 7)]
    public int Banda;

    private RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        rect.localScale = new Vector3(escalaInicial + (AudioSpectrum.bandBuffer[Banda] * multiplicador), escalaInicial + (AudioSpectrum.bandBuffer[Banda] * multiplicador), escalaInicial + (AudioSpectrum.bandBuffer[Banda] * multiplicador));
    }
}
