using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuPausa : MonoBehaviour {

    public GameObject UIfinal;
    public Button FinalPrimerSelect;
    public GameObject UIpausa;
    public Button PausaPrimerSelect;
    public GameObject UIplay;
    public EventSystem eSystem;

    private AudioSource source;
    private int enPausa = 1;
    public bool yaGano;

    private readonly string botonPausa = "Cancel";
    private readonly string scene0 = "0";
    private readonly string scene1 = "1";

    private void Awake()
    {
        UIpausa.SetActive(false);
        UIfinal.SetActive(false);
        UIplay.SetActive(true);
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(botonPausa))
        {
            if (!yaGano)
            {
                enPausa = enPausa + 1;
                if (enPausa == 2)
                {
                    enPausa = 0;
                }

                if (enPausa == 0)
                {
                    //pausa
                    Time.timeScale = 0;
                    UIplay.SetActive(false);
                    UIpausa.SetActive(true);
                    eSystem.SetSelectedGameObject(null);
                    //eSystem.SetSelectedGameObject(PausaPrimerSelect);
                    PausaPrimerSelect.Select();
                    source.Pause();
                    MoverJugador.recibeInputs = false;
                }
                if (enPausa == 1)
                {
                    //play
                    Time.timeScale = 1;
                    UIpausa.SetActive(false);
                    UIplay.SetActive(true);
                    source.UnPause();
                    MoverJugador.recibeInputs = true;
                }
            }

        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        UIpausa.SetActive(false);
        UIplay.SetActive(true);
        enPausa = 0;
        source.UnPause();
        MoverJugador.recibeInputs = true;
    }

    public void Restart()
    {
        Initiate.Fade(scene1, Color.black, 1);
        Time.timeScale = 1;
        UIpausa.SetActive(false);
        UIfinal.SetActive(false);
        UIplay.SetActive(true);
        enPausa = 0;
        source.Stop();
        MoverJugador.recibeInputs = true;
        PlayerPrefs.SetInt("Restart", 1);
    }

    public void Exit()
    {
        Initiate.Fade(scene0, Color.black, 1);
        Time.timeScale = 1;
        MoverJugador.recibeInputs = true;
    }

    public void Final()
    {
        yaGano = true;
        UIplay.SetActive(false);
        UIfinal.SetActive(true);
        Time.timeScale = 0.5f;
        MoverJugador.recibeInputs = false;
        eSystem.SetSelectedGameObject(null);
        FinalPrimerSelect.Select();
    }
}
