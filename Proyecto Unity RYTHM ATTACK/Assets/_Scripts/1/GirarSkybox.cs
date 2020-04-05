using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarSkybox : MonoBehaviour {

    public float VelocidadRotacion;
    private readonly int rotacion_ID = Shader.PropertyToID("_Rotation");
    private Material rSettings;

    private void Awake()
    {
        rSettings = RenderSettings.skybox;
    }

    private void Update()
    {
        rSettings.SetFloat(rotacion_ID, (Time.unscaledTime * VelocidadRotacion - 45));
    }
}