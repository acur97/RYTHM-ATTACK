using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicio : MonoBehaviour {

    public GameObject TVstart;
    public GameObject Cinicial;
    public GameObject Ccanciones;
    public GameObject Cpuntaje;
    public GameObject Ccarga;

    private void Awake()
    {
        TVstart.SetActive(true);
        Cinicial.SetActive(true);
        Ccanciones.SetActive(false);
        Cpuntaje.SetActive(false);
        Ccarga.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
