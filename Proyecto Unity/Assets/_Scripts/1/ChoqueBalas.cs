using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueBalas : MonoBehaviour {

    public GameObject Sparks;
    public Transform padreVfx;

    private static Quaternion rotacionZero = Quaternion.identity;
    private static GameObject spakrsS;
    private static Transform padreS;

    private void Awake()
    {
        spakrsS = Sparks;
        padreS = padreVfx;
    }

    public static void InsanciarVfx(Vector3 pos)
    {
        Instantiate(spakrsS, pos, rotacionZero, padreS);
    }
}