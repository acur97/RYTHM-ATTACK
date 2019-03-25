using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarSkybox : MonoBehaviour {

    public float VelocidadRotacion;

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", (Time.time * VelocidadRotacion - 45));
    }
}
