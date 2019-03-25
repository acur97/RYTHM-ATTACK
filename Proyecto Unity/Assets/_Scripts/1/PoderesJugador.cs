using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderesJugador : MonoBehaviour {

    public AudioSource source;

    private int activar = 0;

    private void Update()
    {
        if (Puntaje.poderCero)
        {
            activar = 0;
            Puntaje.subidaPoder = true;
            source.pitch = 1;
        }

        if (Input.GetButtonDown("Poder 1"))
        {
            activar += 1;
            if (activar == 1)
            {
                Puntaje.subidaPoder = false;
                source.pitch = 0.5f;
            }
            if (activar == 2)
            {
                activar = 0;
                Puntaje.subidaPoder = true;
                source.pitch = 1;
            }
        }
    }
}
