using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavIconos : MonoBehaviour {

    public Transform centro;
    public float multipli = 50;
    [Space]
    public float multipliM;

    private float multiplicador;
    private float espacio;
    private RectTransform rect;
    private float escala;
    private bool Sel;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        multiplicador = (multipli / Screen.dpi);
        multiplicador = multiplicador / 10;
    }

    public void SeleccionarM()
    {
        Sel = true;
    }

   public void DeseleccionarM()
    {
        Sel = false;
    }

    private void Update()
    {
        espacio = Vector2.Distance(transform.position, centro.position);
        if (Sel)
        {
            escala = (1 - (espacio * multiplicador) + (AudioSpectrum.amplitude * multipliM));
        }
        else
        {
            escala = 1 - (espacio * multiplicador);
        }
        rect.localScale = new Vector3(escala, escala, escala);
    }
}
