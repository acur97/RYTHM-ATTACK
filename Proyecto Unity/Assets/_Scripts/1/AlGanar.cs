using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlGanar : MonoBehaviour {

    public Puntaje ptsFinal;

    private float duracion;
    private AudioSource Source;
    private SEF_Equalizer equalizer;
    private MenuPausa menus;
    private bool Ganaste;

    private void Awake()
    {
        Source = GetComponent<AudioSource>();
        equalizer = GetComponent<SEF_Equalizer>();
        menus = GetComponent<MenuPausa>();
    }

    private void Update()
    {
        duracion = (Source.clip.length + Source.time - Source.clip.length) / Source.clip.length;

        if (equalizer.highFreq == 0 && equalizer.midFreq == 0 && equalizer.lowFreq == 0)
        {
            Ganaste = true;
        }
        if (duracion == 1)
        {
            Ganaste = true;
        }

        if (Ganaste)
        {
            menus.Final();
            ptsFinal.ActualizarPuntaje();
        }
    }
}