using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMtrigger : MonoBehaviour {

    public double BPM = 142;
    public double Fbpm = 0;
    public double bajada = 0.1f;
    public AudioSource source;

    private void OnEnable()
    {
        Fbpm = BPM / 60;
    }

    private void FixedUpdate()
    {
        Fbpm -= bajada;

        if (Fbpm <= 0)
        {
            Debug.Log("beat");
            Fbpm = BPM / 60;
        }

        
    }
}
