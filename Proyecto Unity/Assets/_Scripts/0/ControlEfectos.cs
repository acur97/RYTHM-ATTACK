using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ControlEfectos : MonoBehaviour {

    public float multiplicadorChroma = 0.03f;
    public float multiplicadorSaturation = 10;

    private PostProcessVolume post;
    private ChromaticAberration chroma;
    private ColorGrading grading;

    private void Awake()
    {
        post = GetComponent<PostProcessVolume>();
        post.profile.TryGetSettings(out chroma);
        post.profile.TryGetSettings(out grading);
    }

    private void Update()
    {
        chroma.intensity.value = (0.2f + (AudioSpectrum.freqBand[0] * multiplicadorChroma));
        grading.saturation.value = (AudioSpectrum.amplitudeBuffer * multiplicadorSaturation) - 5;
    }
}
