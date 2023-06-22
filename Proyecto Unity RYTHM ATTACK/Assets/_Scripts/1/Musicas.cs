using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

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
    [Space]
    public TextMeshProUGUI CancionPausa;

    private AudioSource source;
    private readonly string D_facil = "Facil";
    private readonly string D_medio = "Medio";
    private readonly string D_dificil = "Dificil";
    private readonly string _Restart = "Restart";

    public static CancionesPak pak;

    private void Awake()
    {
        source = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt(_Restart) == 1)
        {
            pak = MostrarInfoCancion.pakS;
        }
        if (pak != null)
        {
            source.clip = pak.Cancion;
            source.volume = pak.Volumen;

            Sonda1.sprite = pak.FormaDeOnda;
            Sonda2.sprite = pak.FormaDeOnda;

            if (pak.Dificultad.ToString() == D_facil)
            {
                RenderSettings.skybox = SkyEasy;
                RenderSettings.ambientSkyColor = EasySky;
                RenderSettings.ambientEquatorColor = Easyquator;
                RenderSettings.ambientGroundColor = EasyGround;
            }
            if (pak.Dificultad.ToString() == D_medio)
            {
                RenderSettings.skybox = SkyMid;
                RenderSettings.ambientSkyColor = MidSky;
                RenderSettings.ambientEquatorColor = Midquator;
                RenderSettings.ambientGroundColor = MidGround;
            }
            if (pak.Dificultad.ToString() == D_dificil)
            {
                RenderSettings.skybox = SkyHard;
                RenderSettings.ambientSkyColor = HardSky;
                RenderSettings.ambientEquatorColor = Hardquator;
                RenderSettings.ambientGroundColor = HardGround;
            }

            CancionPausa.text = pak.NombreCancion + " - " + pak.Artista;
        }
        else
        {
            Debug.LogWarning("SinMenu");
        }
        
    }

    private void Start()
    {
        source.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Reset PlayerPrefs");
            PlayerPrefs.SetInt("tabla #1_valor", 0);
            PlayerPrefs.SetString("tabla #1_nombre", "----------");
            PlayerPrefs.SetString("tabla #1_cancion", "----------");

            PlayerPrefs.SetInt("tabla #2_valor", 0);
            PlayerPrefs.SetString("tabla #2_nombre", "----------");
            PlayerPrefs.SetString("tabla #2_cancion", "----------");

            PlayerPrefs.SetInt("tabla #3_valor", 0);
            PlayerPrefs.SetString("tabla #3_nombre", "----------");
            PlayerPrefs.SetString("tabla #3_cancion", "----------");

            PlayerPrefs.SetInt("tabla #4_valor", 0);
            PlayerPrefs.SetString("tabla #4_nombre", "----------");
            PlayerPrefs.SetString("tabla #4_cancion", "----------");

            PlayerPrefs.SetInt("tabla #5_valor", 0);
            PlayerPrefs.SetString("tabla #5_nombre", "----------");
            PlayerPrefs.SetString("tabla #5_cancion", "----------");
        }
    }
}