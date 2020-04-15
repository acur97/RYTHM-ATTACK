using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolActivos : MonoBehaviour
{
    public static PoolActivos Pool;

    public Transform Padre;
    ///
    [Space]
    public int Count_balaJugador;
    public GameObject P_balaJugador;
    private List<GameObject> Objs_balaJugador = new List<GameObject>();
    private Transform Root_balaJugador;
    ///
    [HideInInspector]
    public float VelocidadBalaEnemigo;
    [Space]
    public int Count_balaEnemigoAltos;
    public GameObject P_balaEnemigoAltos;
    private List<GameObject> Objs_balaEnemigoAltos = new List<GameObject>();
    private List<Bala> Bala_balaEnemigoAltos = new List<Bala>();
    private Transform Root_balaEnemigoAltos;

    public int Count_balaEnemigoMedios;
    public GameObject P_balaEnemigoMedios;
    private List<GameObject> Objs_balaEnemigoMedios = new List<GameObject>();
    private List<Bala> Bala_balaEnemigoMedios = new List<Bala>();
    private Transform Root_balaEnemigoMedios;

    public int Count_balaEnemigoBajos;
    public GameObject P_balaEnemigoBajos;
    private List<GameObject> Objs_balaEnemigoBajos = new List<GameObject>();
    private List<Bala> Bala_balaEnemigoBajos = new List<Bala>();
    private Transform Root_balaEnemigoBajos;
    ///
    [Space]
    public int Count_VFXchoqueJugador;
    public GameObject P_VFXchoqueJugador;
    private List<GameObject> Objs_VFXchoqueJugador = new List<GameObject>();
    private Transform Root_VFXchoqueJugador;

    public int Count_VFXchoqueEnemigo;
    public GameObject P_VFXchoqueEnemigo;
    private List<GameObject> Objs_VFXchoqueEnemigo = new List<GameObject>();
    private Transform Root_VFXchoqueEnemigo;

    public int Count_VFXchoqueEntreBalas;
    public GameObject P_VFXchoqueEntreBalas;
    private List<GameObject> Objs_VFXchoqueEntreBalas = new List<GameObject>();
    private Transform Root_VFXchoqueEntreBalas;

    public int Count_VFXc50puntos;
    public GameObject P_VFXc50puntos;
    private List<GameObject> Objs_VFXc50puntos = new List<GameObject>();
    private Transform Root_VFXc50puntos;

    /// 

    //private static readonly Vector3 ZeroVector3 = new Vector3(0, 0, 0);
    //private static readonly Quaternion ZeroQuaternion = new Quaternion(0, 0, 0, 1);

    public enum TipoBala { altos, medios, bajos }

    private void Awake()
    {
        Pool = this;
        VelocidadBalaEnemigo = P_balaEnemigoAltos.GetComponent<Bala>().Velocidad;

        //Objs_balaJugador = new List<GameObject>();
        Root_balaJugador = new GameObject("Root_balaJugador").transform;
        Root_balaJugador.parent = Padre;
        for (int i = 0; i < Count_balaJugador; i++)
        {
            GameObject ob = Instantiate(P_balaJugador, Root_balaJugador);
            ob.SetActive(false);
            Objs_balaJugador.Add(ob);
        }
        ///
        //Objs_balaEnemigoAltos = new GameObject[Count_balaEnemigoAltos];
        //Bala_balaEnemigoAltos = new Bala[Count_balaEnemigoAltos];
        Root_balaEnemigoAltos = new GameObject("Root_balaEnemigoAltos").transform;
        Root_balaEnemigoAltos.parent = Padre;
        for (int i = 0; i < Count_balaEnemigoAltos; i++)
        {
            //Objs_balaEnemigoAltos.Add(Instantiate(P_balaEnemigoAltos, Root_balaEnemigoAltos));
            //Objs_balaEnemigoAltos[i].SetActive(false);
            //Bala_balaEnemigoAltos.Add(Objs_balaEnemigoAltos[i].GetComponent<Bala>());

            GameObject ob = Instantiate(P_balaEnemigoAltos, Root_balaEnemigoAltos);
            ob.SetActive(false);
            Objs_balaEnemigoAltos.Add(ob);
            Bala_balaEnemigoAltos.Add(ob.GetComponent<Bala>());
        }

        //Objs_balaEnemigoMedios = new GameObject[Count_balaEnemigoMedios];
        //Bala_balaEnemigoMedios = new Bala[Count_balaEnemigoMedios];
        Root_balaEnemigoMedios = new GameObject("Root_balaEnemigoMedios").transform;
        Root_balaEnemigoMedios.parent = Padre;
        for (int i = 0; i < Count_balaEnemigoMedios; i++)
        {
            //Objs_balaEnemigoMedios.Add(Instantiate(P_balaEnemigoMedios, Root_balaEnemigoMedios));
            //Objs_balaEnemigoMedios[i].SetActive(false);
            //Bala_balaEnemigoMedios.Add(Objs_balaEnemigoMedios[i].GetComponent<Bala>());

            GameObject ob = Instantiate(P_balaEnemigoMedios, Root_balaEnemigoMedios);
            ob.SetActive(false);
            Objs_balaEnemigoMedios.Add(ob);
            Bala_balaEnemigoMedios.Add(ob.GetComponent<Bala>());
        }

        //Objs_balaEnemigoBajos = new GameObject[Count_balaEnemigoBajos];
        //Bala_balaEnemigoBajos = new Bala[Count_balaEnemigoBajos];
        Root_balaEnemigoBajos = new GameObject("Root_balaEnemigoBajos").transform;
        Root_balaEnemigoBajos.parent = Padre;
        for (int i = 0; i < Count_balaEnemigoBajos; i++)
        {
            //Objs_balaEnemigoBajos.Add(Instantiate(P_balaEnemigoBajos, Root_balaEnemigoBajos));
            //Objs_balaEnemigoBajos[i].SetActive(false);
            //Bala_balaEnemigoBajos.Add(Objs_balaEnemigoBajos[i].GetComponent<Bala>());

            GameObject ob = Instantiate(P_balaEnemigoBajos, Root_balaEnemigoBajos);
            ob.SetActive(false);
            Objs_balaEnemigoBajos.Add(ob);
            Bala_balaEnemigoBajos.Add(ob.GetComponent<Bala>());
        }
        ///
        //Objs_VFXchoqueJugador = new GameObject[Count_VFXchoqueJugador];
        Root_VFXchoqueJugador = new GameObject("Root_VFXchoqueJugador").transform;
        Root_VFXchoqueJugador.parent = Padre;
        for (int i = 0; i < Count_VFXchoqueJugador; i++)
        {
            //Objs_VFXchoqueJugador.Add(Instantiate(P_VFXchoqueJugador, Root_VFXchoqueJugador));
            //Objs_VFXchoqueJugador[i].SetActive(false);

            GameObject ob = Instantiate(P_VFXchoqueJugador, Root_VFXchoqueJugador);
            ob.SetActive(false);
            Objs_VFXchoqueJugador.Add(ob);
        }

        //Objs_VFXchoqueEnemigo = new GameObject[Count_VFXchoqueEnemigo];
        Root_VFXchoqueEnemigo = new GameObject("Root_VFXchoqueEnemigo").transform;
        Root_VFXchoqueEnemigo.parent = Padre;
        for (int i = 0; i < Count_VFXchoqueEnemigo; i++)
        {
            //Objs_VFXchoqueEnemigo.Add(Instantiate(P_VFXchoqueEnemigo, Root_VFXchoqueEnemigo));
            //Objs_VFXchoqueEnemigo[i].SetActive(false);

            GameObject ob = Instantiate(P_VFXchoqueEnemigo, Root_VFXchoqueEnemigo);
            ob.SetActive(false);
            Objs_VFXchoqueEnemigo.Add(ob);
        }

        //Objs_VFXchoqueEntreBalas = new GameObject[Count_VFXchoqueEntreBalas];
        Root_VFXchoqueEntreBalas = new GameObject("Root_VFXchoqueEntreBalas").transform;
        Root_VFXchoqueEntreBalas.parent = Padre;
        for (int i = 0; i < Count_VFXchoqueEntreBalas; i++)
        {
            //Objs_VFXchoqueEntreBalas.Add(Instantiate(P_VFXchoqueEntreBalas, Root_VFXchoqueEntreBalas));
            //Objs_VFXchoqueEntreBalas[i].SetActive(false);

            GameObject ob = Instantiate(P_VFXchoqueEntreBalas, Root_VFXchoqueEntreBalas);
            ob.SetActive(false);
            Objs_VFXchoqueEntreBalas.Add(ob);
        }

        //Objs_VFXc50puntos = new GameObject[Count_VFXc50puntos];
        Root_VFXc50puntos = new GameObject("Root_VFXc50puntos").transform;
        Root_VFXc50puntos.parent = Padre;
        for (int i = 0; i < Count_VFXc50puntos; i++)
        {
            //Objs_VFXc50puntos.Add(Instantiate(P_VFXc50puntos, Root_VFXc50puntos));
            //Objs_VFXc50puntos[i].SetActive(false);

            GameObject ob = Instantiate(P_VFXc50puntos, Root_VFXc50puntos);
            ob.SetActive(false);
            Objs_VFXc50puntos.Add(ob);
        }
    }

    private void Update()
    {
        if (VelocidadBalaEnemigo != 0)
        {
            for (int i = 0; i < Count_balaEnemigoAltos; i++)
            {
                Bala_balaEnemigoAltos[i].Velocidad = VelocidadBalaEnemigo;
            }
            for (int i = 0; i < Count_balaEnemigoMedios; i++)
            {
                Bala_balaEnemigoMedios[i].Velocidad = VelocidadBalaEnemigo;
            }
            for (int i = 0; i < Count_balaEnemigoBajos; i++)
            {
                Bala_balaEnemigoBajos[i].Velocidad = VelocidadBalaEnemigo;
            }
        }
    }

    public int AumentarPool(int Count, List<GameObject> Objs, GameObject prefab, Transform padre)
    {
        int newCount = Count + (Count / 3);
        for (int i = 0; i < newCount; i++)
        {
            GameObject ob = prefab;
            ob.SetActive(false);
            Objs.Add(Instantiate(ob, padre));
        }
        return newCount;
    }
    public int AumentarPool(int Count, List<GameObject> Objs, GameObject prefab, Transform padre, List<Bala> Bala)
    {
        int newCount = Count + (Count / 3);
        for (int i = 0; i < newCount; i++)
        {
            GameObject ob = prefab;
            ob.SetActive(false);
            Objs.Add(Instantiate(ob, padre));
            Bala.Add(ob.GetComponent<Bala>());
        }
        return newCount;
    }

    public void I_BalaJugador(Vector3 _posicion)
    {
        int i;
        for (i = 0; i < Count_balaJugador; i++)
        {
            if (!Objs_balaJugador[i].activeSelf)
            {
                Objs_balaJugador[i].transform.position = _posicion;
                Objs_balaJugador[i].SetActive(true);
                break;
            }
            else
            {
                continue;
            }
        }
        if (i == Count_balaJugador)
        {
            Debug.LogWarning("Falta pool !");
            Count_balaJugador = AumentarPool(Count_balaJugador, Objs_balaJugador, P_balaJugador, Root_balaJugador);
            Debug.LogWarning("Agregado.");
        }
    }

    public void I_BalaEnemigo(Vector3 _posicion, TipoBala _tBala)
    {
        switch (_tBala)
        {
            case TipoBala.altos:
                int i;
                for (i = 0; i < Count_balaEnemigoAltos; i++)
                {
                    if (!Objs_balaEnemigoAltos[i].activeSelf)
                    {
                        Objs_balaEnemigoAltos[i].transform.position = _posicion;
                        Objs_balaEnemigoAltos[i].SetActive(true);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (i == Count_balaEnemigoAltos)
                {
                    Debug.LogWarning("Falta pool !");
                    Count_balaEnemigoAltos = AumentarPool(Count_balaEnemigoAltos, Objs_balaEnemigoAltos, P_balaEnemigoAltos, Root_balaEnemigoAltos, Bala_balaEnemigoAltos);
                    Debug.LogWarning("Agregado.");
                }
                break;
            case TipoBala.medios:
                int j;
                for (j = 0; j < Count_balaEnemigoMedios; j++)
                {
                    if (!Objs_balaEnemigoMedios[j].activeSelf)
                    {
                        Objs_balaEnemigoMedios[j].transform.position = _posicion;
                        Objs_balaEnemigoMedios[j].SetActive(true);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (j == Count_balaEnemigoMedios)
                {
                    Debug.LogWarning("Falta pool !");
                    Count_balaEnemigoMedios = AumentarPool(Count_balaEnemigoMedios, Objs_balaEnemigoMedios, P_balaEnemigoMedios, Root_balaEnemigoMedios, Bala_balaEnemigoMedios);
                    Debug.LogWarning("Agregado.");
                }
                break;
            case TipoBala.bajos:
                int n;
                for (n = 0; n < Count_balaEnemigoBajos; n++)
                {
                    if (!Objs_balaEnemigoBajos[n].activeSelf)
                    {
                        Objs_balaEnemigoBajos[n].transform.position = _posicion;
                        Objs_balaEnemigoBajos[n].SetActive(true);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (n == Count_balaEnemigoBajos)
                {
                    Debug.LogWarning("Falta pool !");
                    Count_balaEnemigoBajos = AumentarPool(Count_balaEnemigoBajos, Objs_balaEnemigoBajos, P_balaEnemigoBajos, Root_balaEnemigoBajos, Bala_balaEnemigoBajos);
                    Debug.LogWarning("Agregado.");
                }
                break;
            default:
                break;
        }
    }

    public void I_VFXchoqueJugador(Vector3 _posicion)
    {
        int i;
        for (i = 0; i < Count_VFXchoqueJugador; i++)
        {
            if (!Objs_VFXchoqueJugador[i].activeSelf)
            {
                Objs_VFXchoqueJugador[i].transform.position = _posicion;
                Objs_VFXchoqueJugador[i].SetActive(true);
                break;
            }
            else
            {
                continue;
            }
        }
        if (i == Count_VFXchoqueJugador)
        {
            Debug.LogWarning("Falta pool !");
            Count_VFXchoqueJugador = AumentarPool(Count_VFXchoqueJugador, Objs_VFXchoqueJugador, P_VFXchoqueJugador, Root_VFXchoqueJugador);
            Debug.LogWarning("Agregado.");
        }
    }

    public void I_VFXchoqueEnemigo(Vector3 _posicion)
    {
        int i;
        for (i = 0; i < Count_VFXchoqueEnemigo; i++)
        {
            if (!Objs_VFXchoqueEnemigo[i].activeSelf)
            {
                Objs_VFXchoqueEnemigo[i].transform.position = _posicion;
                Objs_VFXchoqueEnemigo[i].SetActive(true);
                break;
            }
            else
            {
                continue;
            }
        }
        if (i == Count_VFXchoqueEnemigo)
        {
            Debug.LogWarning("Falta pool !");
            Count_VFXchoqueEnemigo = AumentarPool(Count_VFXchoqueEnemigo, Objs_VFXchoqueEnemigo, P_VFXchoqueEnemigo, Root_VFXchoqueEnemigo);
            Debug.LogWarning("Agregado.");
        }
    }

    public void I_VFXchoqueEntreBalas(Vector3 _posicion)
    {
        int i;
        for (i = 0; i < Count_VFXchoqueEntreBalas; i++)
        {
            if (!Objs_VFXchoqueEntreBalas[i].activeSelf)
            {
                Objs_VFXchoqueEntreBalas[i].transform.position = _posicion;
                Objs_VFXchoqueEntreBalas[i].SetActive(true);
                break;
            }
            else
            {
                continue;
            }
        }
        if (i == Count_VFXchoqueEntreBalas)
        {
            Debug.LogWarning("Falta pool !");
            Count_VFXchoqueEntreBalas = AumentarPool(Count_VFXchoqueEntreBalas, Objs_VFXchoqueEntreBalas, P_VFXchoqueEntreBalas, Root_VFXchoqueEntreBalas);
            Debug.LogWarning("Agregado.");
        }
    }

    public void I_VFXc50puntos(Vector3 _posicion)
    {
        int i;
        for (i = 0; i < Count_VFXc50puntos; i++)
        {
            if (!Objs_VFXc50puntos[i].activeSelf)
            {
                Objs_VFXc50puntos[i].transform.position = _posicion;
                Objs_VFXc50puntos[i].SetActive(true);
                break;
            }
            else
            {
                continue;
            }
        }
        if (i == Count_VFXc50puntos)
        {
            Debug.LogWarning("Falta pool !");
            Count_VFXc50puntos = AumentarPool(Count_VFXc50puntos, Objs_VFXc50puntos, P_VFXc50puntos, Root_VFXc50puntos);
            Debug.LogWarning("Agregado.");
        }
    }
}