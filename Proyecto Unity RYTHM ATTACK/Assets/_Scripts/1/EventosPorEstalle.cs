using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosPorEstalle : MonoBehaviour {

    private AudioSource source;
    public Animator anim;
    private int numeroEstalle = 0;
    private MenuPausa mPausa;

    private readonly int estalleID = Animator.StringToHash("estalleID");
    private readonly int estalle = Animator.StringToHash("estalle");

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        mPausa = GetComponent<MenuPausa>();
    }

    private void Update()
    {
        if (!mPausa.yaGano && Musicas.pak != null && source.time > Musicas.pak.Estalle[numeroEstalle])
        {
            anim.SetInteger(estalleID, Random.Range(1, 4));
            anim.SetTrigger(estalle);
            numeroEstalle += 1;
        }
    }
}