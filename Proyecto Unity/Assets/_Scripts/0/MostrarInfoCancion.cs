using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MostrarInfoCancion : MonoBehaviour {

    public Text artista;
    public Image logoCancion;
    public Slider dificultad;
    public Image sliderColor;
    [ColorUsage(false)]
    public Color Cdificil = Color.red;
    [ColorUsage(false)]
    public Color Cmedio = Color.yellow;
    [ColorUsage(false)]
    public Color Cfacil = Color.green;
    public Text puntajeCancion;
    [Space]
    public CancionesPak pak;
    [Space]
    public AudioSource source;
    [Space]
    public Cargando cargar;
    [Space]
    public UnityEvent OnCancel;
    
    private readonly string RecordPorCancion = "RecordDe_";
    private string record_cancionN;
    private int Svalor;
    private float duracion;

    private float speed1;
    private float speed2;

    private void Awake()
    {
        dificultad.value = 0;
    }

    public void MandarInfo(CancionesPak pakC)
    {
        pak = pakC;
        ActualizarInfo();
    }

    public void ActualizarInfo()
    {
        source.Stop();
        StopAllCoroutines();
        artista.text = pak.Artista;
        logoCancion.sprite = pak.LogoCancion;
        if (pak.Dificultad.ToString() == "Facil")
        {
            Svalor = 1;
        }
        if (pak.Dificultad.ToString() == "Medio")
        {
            Svalor = 2;
        }
        if (pak.Dificultad.ToString() == "Dificil")
        {
            Svalor = 3;
        }
        record_cancionN = RecordPorCancion + pak.NombreCancion;
        if (PlayerPrefs.HasKey(record_cancionN))
        {
            puntajeCancion.text = "Record:" + "\n" + "\n" + PlayerPrefs.GetString(record_cancionN + 2) + "\n" + PlayerPrefs.GetInt(record_cancionN).ToString();
        }
        else
        {
            puntajeCancion.text = "No record";
        }
        StartCoroutine(ChangeSpeed1(dificultad.value, Svalor, 0.25f));
        StartCoroutine(IniciarPreviewCancion());

    }

    IEnumerator ChangeSpeed1(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed1 = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed1 = v_end;
    }

    IEnumerator IniciarPreviewCancion()
    {
        yield return new WaitForSeconds(1);
        source.clip = pak.Cancion;
        source.Play();
        source.time = pak.inicioPreview;
        StartCoroutine(ChangeSpeed2(0, pak.Volumen, 0.5f));
    }

    IEnumerator ChangeSpeed2(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            speed2 = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        speed2 = v_end;
    }

    private void Update()
    {
        dificultad.value = speed1;
        source.volume = speed2;

        if (Input.GetButtonDown("Cancel"))
        {
            OnCancel.Invoke();
        }
    }

    public void SeleccionarCancion()
    {
        Musicas.pak = pak;
        StartCoroutine(ChangeSpeed2(source.volume, 0, 0.5f));
        cargar.IniciarCarga();
    }
}