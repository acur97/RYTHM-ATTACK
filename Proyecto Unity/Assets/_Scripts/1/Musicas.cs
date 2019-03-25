using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musicas : MonoBehaviour {

    public DisparoPorBanda Daltos;
    public DisparoPorBanda Dmedios;
    public DisparoPorBanda Dbajos;
    [Space]
    public Material SkyEasy;
    [ColorUsage(false, true)]
    public Color EasySky;
    [ColorUsage(false, true)]
    public Color Easyquator;
    [ColorUsage(false, true)]
    public Color EasyGround;
    [Space]
    public Material SkyMid;
    [ColorUsage(false, true)]
    public Color MidSky;
    [ColorUsage(false, true)]
    public Color Midquator;
    [ColorUsage(false, true)]
    public Color MidGround;
    [Space]
    public Material SkyHard;
    [ColorUsage(false, true)]
    public Color HardSky;
    [ColorUsage(false, true)]
    public Color Hardquator;
    [ColorUsage(false, true)]
    public Color HardGround;
    [Space]
    public Image Sonda1;
    public Image Sonda2;

    private AudioSource source;
    
    public static CancionesPak pak;
    

    private void Awake()
    {
        source = GetComponent<AudioSource>();

        source.clip = pak.Cancion;
        source.volume = pak.Volumen;

        Sonda1.sprite = pak.FormaDeOnda;
        Sonda2.sprite = pak.FormaDeOnda;

        if (pak.Dificultad.ToString() == "Facil")
        {
            RenderSettings.skybox = SkyEasy;
            RenderSettings.ambientSkyColor = EasySky;
            RenderSettings.ambientEquatorColor = Easyquator;
            RenderSettings.ambientGroundColor = EasyGround;
        }
        if (pak.Dificultad.ToString() == "Medio")
        {
            RenderSettings.skybox = SkyMid;
            RenderSettings.ambientSkyColor = MidSky;
            RenderSettings.ambientEquatorColor = Midquator;
            RenderSettings.ambientGroundColor = MidGround;
        }
        if (pak.Dificultad.ToString() == "Dificil")
        {
            RenderSettings.skybox = SkyHard;
            RenderSettings.ambientSkyColor = HardSky;
            RenderSettings.ambientEquatorColor = Hardquator;
            RenderSettings.ambientGroundColor = HardGround;
        }
    }

    private void Start()
    {
        source.Play();
    }
}
