using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosPorEstalle : MonoBehaviour {

    private AudioSource source;
    public Animator anim;
    private int numeroEstalle = 0;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (source.time > Musicas.pak.Estalle[numeroEstalle])
        {
            anim.SetInteger("estalleID", Random.Range(1, 4));
            anim.SetTrigger("estalle");
            numeroEstalle += 1;
        }
    }
}