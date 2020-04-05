using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cancion", menuName = "Nueva Cancion Pak")]
public class CancionesPak : ScriptableObject
{
    [Header("Atributos sobre la Cancion")]
    public string NombreCancion;
    public string Artista;
    public Sprite LogoCancion;
    public Sprite FormaDeOnda;
    public enum Dif {Facil, Medio, Dificil}
    [Space]
    public Dif Dificultad;
    [Range(0, 1)]
    public float Volumen = 0.5f;
    [Space]
    public AudioClip Cancion;
    public float inicioPreview = 30f;
    [Space]
    public float[] Estalle;
}