using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muere50puntos : MonoBehaviour {

    public float tiempoMuerte;
    private float tiempo;

    private void OnEnable()
    {
        tiempo = 1;
    }

    private void Update()
    {
        tiempo -= tiempoMuerte * Time.deltaTime;
        if (tiempo <= 0)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
