using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesLagInicial : MonoBehaviour {
    
    public GameObject hit;
    public GameObject hit1;
    public GameObject puntos50;
    public GameObject bala1;
    public GameObject bala2;
    public GameObject bala3;
    public GameObject bala4;
    public GameObject sparks;

    private void Awake()
    {
        Instantiate(hit, transform);
        Instantiate(hit1, transform);
        Instantiate(puntos50, transform);
        Instantiate(bala1, transform);
        Instantiate(bala2, transform);
        Instantiate(bala3, transform);
        Instantiate(bala4, transform);
        Instantiate(sparks, transform);
    }
}