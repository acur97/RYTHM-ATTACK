using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour {

    public GameObject tower;
    private DisparoPorBanda disp;
    private MovimientoEnemigos mov;
    public Renderer[] luces;
    public GameObject VFXexplocion;
    public Puntaje pts;
    public enum Bandas {altos, medios, bajos};
    public Bandas EQ;
    public SEF_Equalizer equalizer;
    public float Vida;
    [Space]
    public GameObject hit;
    public GameObject puntos50;
    private Vector3 puntos50offset;
    public Transform padreHit;

    private Quaternion rotacionZero = Quaternion.identity;

    private readonly string proyectil = "Proyectiles";
    private readonly int emission = Shader.PropertyToID("_EmissionColor");

    private void Awake()
    {
        disp = tower.GetComponent<DisparoPorBanda>();
        mov = tower.GetComponent<MovimientoEnemigos>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(proyectil))
        {
            if (Vida >= 0)
            {
                Vida -= 1;
                pts.AddPuntos(1);
                Instantiate(hit, other.transform.position, rotacionZero, padreHit);
                puntos50offset = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 2.5f);
                Instantiate(puntos50, puntos50offset, rotacionZero, padreHit);
                Destroy(other.gameObject);
            }
            else
            {
                if (EQ == Bandas.altos)
                {
                    equalizer.highFreq = 0;
                }
                if (EQ == Bandas.medios)
                {
                    equalizer.midFreq = 0;
                }
                if (EQ == Bandas.bajos)
                {
                    equalizer.lowFreq = 0;
                }
                pts.AddPuntos(2);
                mov.VelocidadBanda = 0;
                disp.muerto = true;
                for (int i = 0; i < luces.Length; i++)
                {
                    luces[i].material.SetColor(emission, Color.black);
                }
                VFXexplocion.SetActive(true);
                disp.muerto = true;
                Destroy(gameObject);
            }
        }
    }
}
