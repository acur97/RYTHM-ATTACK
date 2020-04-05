using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesNave : MonoBehaviour
{
    public Material rojos;
    public Material rojosNave;
    public float intensidad1;
    [ColorUsage(false, true)]
    public Color naveC = new Color(191, 48, 0);
    public float minimo1;
    [ColorUsage(false, true)]
    public Color rojo = new Color(191, 48, 0);
    [Space]
    public Material blancos;
    public float intensidad2;
    public float minimo2;
    [ColorUsage(false, true)]
    public Color blanco = new Color(139, 141, 191);

    private Color rojo2;
    private Color rojo3;
    private Color blanco2;
    private float valor1;
    private float valor2;
    private float valor3;

    private readonly int emisionColor = Shader.PropertyToID("_EmissionColor");

    private void Update()
    {
        valor1 = (AudioSpectrum.bandBuffer[1] * intensidad1) + minimo1;
        valor2 = (AudioSpectrum.amplitudeBuffer * intensidad2) + minimo2;
        valor3 = (AudioSpectrum.bandBuffer[0] * intensidad1) + minimo1;
        rojo2 = rojo * valor1;
        rojo3 = naveC * (valor3 * 2.75f);
        blanco2 = blanco * valor2;

        rojos.SetColor(emisionColor, rojo2);
        rojosNave.SetColor(emisionColor, rojo3);
        blancos.SetColor(emisionColor, blanco2);
    }
}
