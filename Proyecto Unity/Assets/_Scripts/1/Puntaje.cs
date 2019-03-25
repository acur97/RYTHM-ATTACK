using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour {

    public Text score;
    public Text scoreFinal;
    public Slider Scombos;
    public float bajadaCombos;
    public float subidaCombos;
    public Text TcombosX;
    public Outline[] TcombosGlow;
    public float bajadaVida;
    public VidaNave vidaN;
    public int puntajeBala = 50;
    public int puntajeExplocion = 1000;
    [Space]
    public GameObject TextoPuntaje;
    public GameObject PanelNormal;
    public GameObject PanelRecord;
    public PuntajeTabla puntajeT;
    public InputField inputName;
    [Space]
    public Slider Spoder;
    public float tiempoCombos;

    public static int scoreBala;
    public static int scoreExplocion;
    public static int Score;
    public static bool SiRecord;
    public static bool subidaPoder = true;
    public static bool poderCero = false;

    private int puntaje = 0;
    private float Fcombos;
    private float combosMulti = 1;
    private string titulo_anterior;
    private float poderValor;

    private readonly string T1_nombre = "tabla #1_nombre";

    private void Awake()
    {
        scoreBala = puntajeBala;
        scoreExplocion = puntajeExplocion;
        puntaje = 0;
        score.text = puntaje.ToString();
        Scombos.value = 1f;
        Fcombos = 1f;
        Spoder.value = 0;
    }

    private void Update()
    {
        if (subidaPoder)
        {
            if (Spoder.value < Spoder.maxValue)
            {
                Spoder.value += (tiempoCombos / 2);
            }
        }
        else
        {
            if (Spoder.value > 0)
            {
                Spoder.value -= tiempoCombos;
            }
        }
        if (Spoder.value <= 0)
        {
            poderCero = true;
        }
        else
        {
            poderCero = false;
        }

        if (Fcombos >= 0)
        {
            Fcombos = Fcombos - (bajadaCombos * combosMulti);
            Scombos.value = Fcombos;
        }
        if (Fcombos <= 0)
        {
            vidaN.BajarVida(bajadaVida);
        }

        for (int i = 0; i < TcombosGlow.Length; i++)
        {
            TcombosGlow[i].effectColor = new Color(1, 0.25f, 0, (Fcombos * 0.02f));
        }

        if (Fcombos >= 0 && Fcombos < 1)
        {
            Scombos.minValue = 0;
            Scombos.maxValue = 1;
            combosMulti = 1;
            TcombosX.text = "x1";
        }
        if (Fcombos >= 1 && Fcombos < 3)
        {
            Scombos.minValue = 1;
            Scombos.maxValue = 3;
            combosMulti = 2;
            TcombosX.text = "x2";
        }
        if (Fcombos >= 3 && Fcombos < 6)
        {
            Scombos.minValue = 3;
            Scombos.maxValue = 6;
            combosMulti = 3;
            TcombosX.text = "x3";
        }
        if (Fcombos >= 6 && Fcombos < 10)
        {
            Scombos.minValue = 6;
            Scombos.maxValue = 10;
            combosMulti = 4;
            TcombosX.text = "x4";
        }
        if (Fcombos >= 10 && Fcombos < 15)
        {
            Scombos.minValue = 10;
            Scombos.maxValue = 15;
            combosMulti = 5;
            TcombosX.text = "x5";
        }
    }

    public void AddPuntos(int vaina)
    {
        
        if (vaina == 1)
        {
            puntaje = puntaje + puntajeBala;
            score.text = puntaje.ToString();

            if (Fcombos <= 15)
            {
                Fcombos = Fcombos + subidaCombos;
                Scombos.value = Fcombos;
            }
        }
        if (vaina == 2)
        {
            puntaje = puntaje + puntajeExplocion;
            score.text = puntaje.ToString();

            if (Fcombos <= 15)
            {
                Fcombos = Fcombos + (subidaCombos * 2);
                Scombos.value = Fcombos;
            }
        }
    }

    public void ActualizarPuntaje()
    {
        puntajeT.PreguntaRecord(puntaje);

        if (!PlayerPrefs.HasKey(T1_nombre))
        {
            PanelNormal.SetActive(false);
            PanelRecord.SetActive(true);
            inputName.Select();
            titulo_anterior = "NEW RECORD: " + puntaje + " !";
            scoreFinal.text = "NEW RECORD: " + puntaje + " !" + "\n" + "ENTER YOUR NAME";
        }
        if (SiRecord)
        {
            PanelNormal.SetActive(false);
            PanelRecord.SetActive(true);
            inputName.Select();
            titulo_anterior = "NEW RECORD: " + puntaje + " !";
            scoreFinal.text = "NEW RECORD: " + puntaje + " !" + "\n" + "ENTER YOUR NAME";
        }
        else
        {
            PanelNormal.SetActive(true);
            PanelRecord.SetActive(false);
            titulo_anterior = "SCORE: " + puntaje;
            scoreFinal.text = "SCORE: " + puntaje;
        }
    }

    public void SubmitRecord(string name)
    {
        puntajeT.NombreDeCancion(Musicas.pak.NombreCancion);
        puntajeT.NombreDeRecord(name);
        puntajeT.NuevoPuntaje(puntaje);
        puntajeT.ActualizarTablaUI();
        PanelRecord.SetActive(false);
        PanelNormal.SetActive(true);
        scoreFinal.text = titulo_anterior;
    }
}
