using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCompleteTime : MonoBehaviour {

    public Slider Sonda;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        Sonda.maxValue = source.clip.length;
        Sonda.value = 0;
    }

    private void Update()
    {
        Sonda.value = source.time;
    }

    public void moverEntreCancion()
    {
        source.time = Sonda.value;
    }
}