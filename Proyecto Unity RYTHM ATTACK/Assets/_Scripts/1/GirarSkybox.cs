using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarSkybox : MonoBehaviour {

    public float VelocidadRotacion;
    private readonly int rotacion_ID = Shader.PropertyToID("_Rotation");
    private Material rSettings;
    private float val;

    private void Start()
    {
        rSettings = RenderSettings.skybox;
    }

    private void Update()
    {
        val += Time.deltaTime * VelocidadRotacion;
        rSettings.SetFloat(rotacion_ID, val);
    }
}