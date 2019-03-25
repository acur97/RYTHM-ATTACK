using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaNave : MonoBehaviour {

    public Puntaje ptsFinal;
    public MenuPausa menus;
    public AudioSource source;
    [Space]
    public Slider Svida;
    public float Vida;
    public GameObject Nave;
    [Space]
    public ExplocionBolas bom;
    public GameObject naveExplota;
    public GameObject naveMisma;
    [Space]
    public GameObject hit;
    public Transform padreHit;

    private Quaternion rotacionZero = Quaternion.identity;

    private void Awake()
    {
        Svida.maxValue = Vida;
        Svida.value = Vida;
        naveExplota.SetActive(false);
    }

    private void Update()
    {
        naveExplota.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Balas")
        {
            if (Vida > 0)
            {
                BajarVida(1);
                Instantiate(hit, other.transform.position, rotacionZero, padreHit);
                Destroy(other.gameObject);

            }
            if (Vida <= 0)
            {
                menus.Final();
                ptsFinal.ActualizarPuntaje();
                naveExplota.SetActive(true);
                bom.Explotar();
                naveMisma.SetActive(false);
                source.volume = 0.25f;
            }
        }

        if (other.tag == "Laser")
        {
            BajarVida(1);
        }
    }

    public void BajarVida(float valor)
    {
        Vida = Vida - valor;
        Svida.value = Vida;
    }
}
