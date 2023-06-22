using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MostrarInfoCancion : MonoBehaviour {

    public TextMeshProUGUI artista;
    public Image logoCancion;
    public Slider dificultad;
    public Image sliderColor;
    [ColorUsage(false)]
    public Color Cdificil = Color.red;
    [ColorUsage(false)]
    public Color Cmedio = Color.yellow;
    [ColorUsage(false)]
    public Color Cfacil = Color.green;
    public TextMeshProUGUI puntajeCancion;
    public RectTransform Content;
    public EventSystem eSystem;
    private GameObject LastSel;
    [Space]
    public CancionesPak pak;
    [Space]
    public AudioSource source;
    [Space]
    public Cargando cargar;
    [Space]
    public UnityEvent OnCancel;

    private Button PrimerSelect;
    private bool PrimeraVez = true;
    private bool Devolver = false;

    //private readonly string RecordPorCancion = "RecordDe_";
    private readonly string cancel = "Cancel";
    private readonly string record = "Record:";
    private readonly string noRecord = "No record";
    private readonly string enter = "\n";
    private readonly string cero = "0";
    private readonly string pakRecords = "0/_#0/_#0/_#0/_#0/_";
    private readonly string facil = "Facil";
    private readonly string medio = "Medio";
    private readonly string dificil = "Dificil";
    private readonly string _Restart = "Restart";

    //private string record_cancionN;
    private int Svalor;
    //private float duracion;

    private float speed1;
    private float speed2;

    private float LastHeight;
    private float LastWidth;
    public RenderTexture UIrt;
    public Camera camUI;

    public static CancionesPak pakS;

    private void Awake()
    {
        LastHeight = Screen.height;
        LastWidth = Screen.width;

        camUI.targetTexture.Release();
        UIrt.height = Screen.height;
        UIrt.width = Screen.width;
        camUI.targetTexture = UIrt;

        PrimerSelect = Content.GetComponentInChildren<Button>();
    }

    private void OnEnable()
    {
        dificultad.value = 0;
    }

    public void MandarInfo(CancionesPak pakC)
    {
        if (!Devolver)
        {
            pak = pakC;
            ActualizarInfo();
            Devolver = false;
        }
    }

    public void QuitarInfo()
    {
        LastSel = eSystem.currentSelectedGameObject;
    }

    public void ActualizarInfo()
    {
        source.Stop();
        StopAllCoroutines();
        artista.text = pak.Artista;
        logoCancion.sprite = pak.LogoCancion;
        if (pak.Dificultad.ToString() == facil)
        {
            Svalor = 1;
        }
        if (pak.Dificultad.ToString() == medio)
        {
            Svalor = 2;
        }
        if (pak.Dificultad.ToString() == dificil)
        {
            Svalor = 3;
        }
        //record_cancionN = RecordPorCancion + pak.NombreCancion;

        if (!PlayerPrefs.HasKey(pak.NombreCancion))
        {
            PlayerPrefs.SetString(pak.NombreCancion, pakRecords);
            Debug.Log("crear string");
        }
        string tablaCancion_string;
        tablaCancion_string = PlayerPrefs.GetString(pak.NombreCancion);
        string[] tablaCancion_array = tablaCancion_string.Split('#');
        string[] beta = tablaCancion_array[0].Split('/');
        string jugador1 = beta[1];
        string puntaje1 = beta[0];
        if (jugador1 == cero)
        {
            puntajeCancion.text = record + enter + enter + jugador1 + enter + puntaje1;
        }
        else
        {
            puntajeCancion.text = noRecord;
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
        yield return new WaitForSecondsRealtime(1);
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

    public void PrimerSel()
    {
        if (PrimeraVez)
        {
            PrimerSelect.Select();
            PrimeraVez = false;
        }
        else
        {
            eSystem.SetSelectedGameObject(LastSel);
            Devolver = false;
        }
    }

    private void Update()
    {
        dificultad.value = speed1;
        source.volume = speed2;

        if (Input.GetButtonDown(cancel))
        {
            OnCancel.Invoke();
            Devolver = true;
        }

        if (LastHeight != Screen.height || LastWidth != Screen.width)
        {
            LastHeight = Screen.height;
            LastWidth = Screen.width;

            camUI.targetTexture.Release();
            UIrt.height = Screen.height;
            UIrt.width = Screen.width;
            camUI.targetTexture = UIrt;
        }
    }

    public void SeleccionarCancion()
    {
        Musicas.pak = pak;
        pakS = pak;
        PlayerPrefs.SetInt(_Restart, 0);
        StartCoroutine(ChangeSpeed2(source.volume, 0, 0.5f));
        cargar.IniciarCarga();
    }
}