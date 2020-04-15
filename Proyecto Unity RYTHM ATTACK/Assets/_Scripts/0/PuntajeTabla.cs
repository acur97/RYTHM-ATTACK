using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class PuntajeTabla : MonoBehaviour {

    public bool Main;
    [Space]
    public TextMeshProUGUI U1_nombre;
    public TextMeshProUGUI U1_valor;
    public TextMeshProUGUI U1_cancion;
    [Space]
    public TextMeshProUGUI U2_nombre;
    public TextMeshProUGUI U2_valor;
    public TextMeshProUGUI U2_cancion;
    [Space]
    public TextMeshProUGUI U3_nombre;
    public TextMeshProUGUI U3_valor;
    public TextMeshProUGUI U3_cancion;
    [Space]
    public TextMeshProUGUI U4_nombre;
    public TextMeshProUGUI U4_valor;
    public TextMeshProUGUI U4_cancion;
    [Space]
    public TextMeshProUGUI U5_nombre;
    public TextMeshProUGUI U5_valor;
    public TextMeshProUGUI U5_cancion;

    private string nombreRecord;
    private string nombreCancion;

    private readonly string T1_nombre = "tabla #1_nombre";
    private readonly string T1_valor = "tabla #1_valor";
    private readonly string T1_cancion = "tabla #1_cancion";
    private readonly string T2_nombre = "tabla #2_nombre";
    private readonly string T2_valor = "tabla #2_valor";
    private readonly string T2_cancion = "tabla #2_cancion";
    private readonly string T3_nombre = "tabla #3_nombre";
    private readonly string T3_valor = "tabla #3_valor";
    private readonly string T3_cancion = "tabla #3_cancion";
    private readonly string T4_nombre = "tabla #4_nombre";
    private readonly string T4_valor = "tabla #4_valor";
    private readonly string T4_cancion = "tabla #4_cancion";
    private readonly string T5_nombre = "tabla #5_nombre";
    private readonly string T5_valor = "tabla #5_valor";
    private readonly string T5_cancion = "tabla #5_cancion";
    private readonly string RecordPorCancion = "RecordDe_";
    private readonly string espacios = "----------";
    private readonly string numeral = "#";
    private readonly string slash = "/";

    private string[] jugadores;
    private int[] puntajes;

    private void Awake()
    {
        if(Main)
        {
            if (!PlayerPrefs.HasKey(T1_nombre))
            {
                PlayerPrefs.SetInt(T1_valor, 0);
                PlayerPrefs.SetString(T1_nombre, espacios);
                PlayerPrefs.SetString(T1_cancion, espacios);
                Debug.Log("crear string");
            }
            if (!PlayerPrefs.HasKey(T2_nombre))
            {
                PlayerPrefs.SetInt(T2_valor, 0);
                PlayerPrefs.SetString(T2_nombre, espacios);
                PlayerPrefs.SetString(T2_cancion, espacios);
                Debug.Log("crear string");
            }
            if (!PlayerPrefs.HasKey(T3_nombre))
            {
                PlayerPrefs.SetInt(T3_valor, 0);
                PlayerPrefs.SetString(T3_nombre, espacios);
                PlayerPrefs.SetString(T3_cancion, espacios);
                Debug.Log("crear string");
            }
            if (!PlayerPrefs.HasKey(T4_nombre))
            {
                PlayerPrefs.SetInt(T4_valor, 0);
                PlayerPrefs.SetString(T4_nombre, espacios);
                PlayerPrefs.SetString(T4_cancion, espacios);
                Debug.Log("crear string");
            }
            if (!PlayerPrefs.HasKey(T5_nombre))
            {
                PlayerPrefs.SetInt(T5_valor, 0);
                PlayerPrefs.SetString(T5_nombre, espacios);
                PlayerPrefs.SetString(T5_cancion, espacios);
                Debug.Log("crear string");
            }

            U1_nombre.text = PlayerPrefs.GetString(T1_nombre);
            U1_valor.text = PlayerPrefs.GetInt(T1_valor).ToString();
            U1_cancion.text = PlayerPrefs.GetString(T1_cancion);

            U2_nombre.text = PlayerPrefs.GetString(T2_nombre);
            U2_valor.text = PlayerPrefs.GetInt(T2_valor).ToString();
            U2_cancion.text = PlayerPrefs.GetString(T2_cancion);

            U3_nombre.text = PlayerPrefs.GetString(T3_nombre);
            U3_valor.text = PlayerPrefs.GetInt(T3_valor).ToString();
            U3_cancion.text = PlayerPrefs.GetString(T3_cancion);

            U4_nombre.text = PlayerPrefs.GetString(T4_nombre);
            U4_valor.text = PlayerPrefs.GetInt(T4_valor).ToString();
            U4_cancion.text = PlayerPrefs.GetString(T4_cancion);

            U5_nombre.text = PlayerPrefs.GetString(T5_nombre);
            U5_valor.text = PlayerPrefs.GetInt(T5_valor).ToString();
            U5_cancion.text = PlayerPrefs.GetString(T5_cancion);
        }
    }

    private void Start()
    {
        /*PlayerPrefs.SetString("Cancion prueba", "4121/juanito#1234213/perd asdf#123/asdf#12343/sasa#423/3223qe");
        test = PlayerPrefs.GetString("Cancion prueba");
        string[] test2 = test.Split('#');
        jugadores = new string[test2.Length];
        puntajes = new string[test2.Length];
        for (int i = 0; i < test2.Length; i++)
        {
            string[] beta = test2[i].Split('/');
            Debug.Log(test2[i]);
            puntajes[i] = beta[0];
            jugadores[i] = beta[1];
        }

        testF = puntajes[0] + "/" +
                jugadores[0] + "#" +
                puntajes[1] + "/" +
                jugadores[1] + "#" +
                puntajes[2] + "/" +
                jugadores[2] + "#" +
                puntajes[3] + "/" +
                jugadores[3] + "#" +
                puntajes[4] + "/" +
                jugadores[4];*/
        //PreguntaRecord(10, Musicas.pak.NombreCancion);
    }

    public void NombreDeRecord(string nombre)
    {
        nombreRecord = nombre;
    }

    public void NombreDeCancion(string nombre)
    {
        nombreCancion = nombre;
    }

    public int PreguntaRecord(int puntaje, string cancion)
    {
        string tablaCancion_string;
        tablaCancion_string = PlayerPrefs.GetString(cancion);
        string[] tablaCancion_array = tablaCancion_string.Split('#');
        jugadores = new string[tablaCancion_array.Length];
        puntajes = new int[tablaCancion_array.Length];
        for (int i = 0; i < tablaCancion_array.Length; i++)
        {
            string[] beta = tablaCancion_array[i].Split('/');
            puntajes[i] = int.Parse(beta[0]);
            jugadores[i] = beta[1];
        }

        if (puntaje >= puntajes[0])
        {
            //Puntaje.SiRecord = true;
            return 1;
        }
        else if (puntaje >= puntajes[1] && puntaje < puntajes[0])
        {
            //Puntaje.SiRecord = true;
            return 2;
        }
        else if (puntaje >= puntajes[2] && puntaje < puntajes[1])
        {
            //Puntaje.SiRecord = true;
            return 3;
        }
        else if (puntaje >= puntajes[3] && puntaje < puntajes[2])
        {
            //Puntaje.SiRecord = true;
            return 4;
        }
        else if (puntaje >= puntajes[4] && puntaje < puntajes[3])
        {
            //Puntaje.SiRecord = true;
            return 5;
        }
        else if (puntaje == 0)
        {
            return 6;
        }
        else
        {
            return 0;
        }
        
        /*if (puntaje >= PlayerPrefs.GetInt(T1_valor))
        {
            //Puntaje.SiRecord = true;
            return 1;
        }
        else if (puntaje >= PlayerPrefs.GetInt(T2_valor) && puntaje < PlayerPrefs.GetInt(T1_valor))
        {
            //Puntaje.SiRecord = true;
            return 2;
        }
        else if (puntaje >= PlayerPrefs.GetInt(T3_valor) && puntaje < PlayerPrefs.GetInt(T2_valor))
        {
            //Puntaje.SiRecord = true;
            return 3;
        }
        else if (puntaje >= PlayerPrefs.GetInt(T4_valor) && puntaje < PlayerPrefs.GetInt(T3_valor))
        {
            //Puntaje.SiRecord = true;
            return 4;
        }
        else if (puntaje >= PlayerPrefs.GetInt(T5_valor) && puntaje < PlayerPrefs.GetInt(T4_valor))
        {
            //Puntaje.SiRecord = true;
            return 5;
        }
        else
        {
            return 0;
        }*/
    }

    public void NuevoPuntaje(int puntaje)
    {
        //Escribir valor de record de cancion si es mayor al anterior
        string RecordDeCancion = RecordPorCancion + nombreCancion;
        /*if (PlayerPrefs.HasKey(RecordDeCancion))
        {
            if (puntaje > PlayerPrefs.GetInt(RecordDeCancion))
            {
                PlayerPrefs.SetInt(RecordDeCancion, puntaje);
                PlayerPrefs.SetString(RecordDeCancion + 2, nombreRecord);
            }
        }
        else
        {
            PlayerPrefs.SetInt(RecordDeCancion, puntaje);
            PlayerPrefs.SetString(RecordDeCancion + 2, nombreRecord);
        }*/
        PlayerPrefs.SetInt(RecordDeCancion, puntaje);
        PlayerPrefs.SetString(RecordDeCancion + 2, nombreRecord);

        if (puntaje >= puntajes[0])
        {
            //puntajes[1] = puntajes[0];
            //puntajes[2] = puntajes[1];
            //puntajes[3] = puntajes[2];
            //puntajes[4] = puntajes[3];

            puntajes[4] = puntajes[3];
            jugadores[4] = jugadores[3];
            puntajes[3] = puntajes[2];
            jugadores[3] = jugadores[2];
            puntajes[2] = puntajes[1];
            jugadores[2] = jugadores[1];
            puntajes[1] = puntajes[0];
            jugadores[1] = jugadores[0];


            puntajes[0] = puntaje;
            jugadores[0] = nombreRecord;
        }
        if (puntaje >= puntajes[1] && puntaje < puntajes[0])
        {
            //puntajes[2] = puntajes[1];
            //puntajes[3] = puntajes[2];
            //puntajes[4] = puntajes[3];

            puntajes[4] = puntajes[3];
            jugadores[4] = jugadores[3];
            puntajes[3] = puntajes[2];
            jugadores[3] = jugadores[2];
            puntajes[2] = puntajes[1];
            jugadores[2] = jugadores[1];

            puntajes[1] = puntaje;
            jugadores[1] = nombreRecord;
        }
        if (puntaje >= puntajes[2] && puntaje < puntajes[1])
        {
            //puntajes[3] = puntajes[2];
            //puntajes[4] = puntajes[3];

            puntajes[4] = puntajes[3];
            jugadores[4] = jugadores[3];
            puntajes[3] = puntajes[2];
            jugadores[3] = jugadores[2];

            puntajes[2] = puntaje;
            jugadores[2] = nombreRecord;
        }
        if (puntaje >= puntajes[3] && puntaje < puntajes[2])
        {
            puntajes[4] = puntajes[3];
            jugadores[4] = jugadores[3];

            puntajes[3] = puntaje;
            jugadores[3] = nombreRecord;
        }
        if (puntaje >= puntajes[4] && puntaje < puntajes[3])
        {
            puntajes[4] = puntaje;
            jugadores[4] = nombreRecord;
        }
        string testF = puntajes[0] + slash +
                jugadores[0] + numeral +
                puntajes[1] + slash +
                jugadores[1] + numeral +
                puntajes[2] + slash +
                jugadores[2] + numeral +
                puntajes[3] + slash +
                jugadores[3] + numeral +
                puntajes[4] + slash +
                jugadores[4];
        PlayerPrefs.SetString(nombreCancion, testF);

        //ReCalcular orden de la tabla si es mayor al #1 actual
        if (puntaje >= PlayerPrefs.GetInt(T1_valor))
        {
            //guardar tabla anterior menos el #5 que quedara eliminado
            int puesto1_valor = PlayerPrefs.GetInt(T1_valor);
            string puesto1_nombre = PlayerPrefs.GetString(T1_nombre);
            string puesto1_cancion = PlayerPrefs.GetString(T1_cancion);

            int puesto2_valor = PlayerPrefs.GetInt(T2_valor);
            string puesto2_nombre = PlayerPrefs.GetString(T2_nombre);
            string puesto2_cancion = PlayerPrefs.GetString(T2_cancion);

            int puesto3_valor = PlayerPrefs.GetInt(T3_valor);
            string puesto3_nombre = PlayerPrefs.GetString(T3_nombre);
            string puesto3_cancion = PlayerPrefs.GetString(T3_cancion);

            int puesto4_valor = PlayerPrefs.GetInt(T4_valor);
            string puesto4_nombre = PlayerPrefs.GetString(T4_nombre);
            string puesto4_cancion = PlayerPrefs.GetString(T4_cancion);

            //guardar nuevos valores con el nuevo #1 hacia abajo
            PlayerPrefs.SetInt(T1_valor, puntaje);
            PlayerPrefs.SetString(T1_nombre, nombreRecord); //puesto que se actualiza #1
            PlayerPrefs.SetString(T1_cancion, nombreCancion);

            PlayerPrefs.SetInt(T2_valor, puesto1_valor);
            PlayerPrefs.SetString(T2_nombre, puesto1_nombre);
            PlayerPrefs.SetString(T2_cancion, puesto1_cancion);

            PlayerPrefs.SetInt(T3_valor, puesto2_valor);
            PlayerPrefs.SetString(T3_nombre, puesto2_nombre);
            PlayerPrefs.SetString(T3_cancion, puesto2_cancion);

            PlayerPrefs.SetInt(T4_valor, puesto3_valor);
            PlayerPrefs.SetString(T4_nombre, puesto3_nombre);
            PlayerPrefs.SetString(T4_cancion, puesto3_cancion);

            PlayerPrefs.SetInt(T5_valor, puesto4_valor);
            PlayerPrefs.SetString(T5_nombre, puesto4_nombre);
            PlayerPrefs.SetString(T5_cancion, puesto4_cancion);
        }

        //ReCalcular orden de la tabla si es mayor al #2 actual y menor que el #1
        if (puntaje >= PlayerPrefs.GetInt(T2_valor) && puntaje < PlayerPrefs.GetInt(T1_valor))
        {
            //guardar tabla anterior menos el #5 que quedara eliminado y evadiendo el #1
            int puesto2_valor = PlayerPrefs.GetInt(T2_valor);
            string puesto2_nombre = PlayerPrefs.GetString(T2_nombre);
            string puesto2_cancion = PlayerPrefs.GetString(T2_cancion);

            int puesto3_valor = PlayerPrefs.GetInt(T3_valor);
            string puesto3_nombre = PlayerPrefs.GetString(T3_nombre);
            string puesto3_cancion = PlayerPrefs.GetString(T3_cancion);

            int puesto4_valor = PlayerPrefs.GetInt(T4_valor);
            string puesto4_nombre = PlayerPrefs.GetString(T4_nombre);
            string puesto4_cancion = PlayerPrefs.GetString(T4_cancion);

            //guardar nuevos valores con el nuevo #2 hacia abajo
            PlayerPrefs.SetInt(T2_valor, puntaje);
            PlayerPrefs.SetString(T2_nombre, nombreRecord); //puesto que se actualiza #2
            PlayerPrefs.SetString(T2_cancion, nombreCancion);

            PlayerPrefs.SetInt(T3_valor, puesto2_valor);
            PlayerPrefs.SetString(T3_nombre, puesto2_nombre);
            PlayerPrefs.SetString(T3_cancion, puesto2_cancion);

            PlayerPrefs.SetInt(T4_valor, puesto3_valor);
            PlayerPrefs.SetString(T4_nombre, puesto3_nombre);
            PlayerPrefs.SetString(T4_cancion, puesto3_cancion);

            PlayerPrefs.SetInt(T5_valor, puesto4_valor);
            PlayerPrefs.SetString(T5_nombre, puesto4_nombre);
            PlayerPrefs.SetString(T5_cancion, puesto4_cancion);
        }

        //ReCalcular orden de la tabla si es mayor al #3 actual y menor que el #2
        if (puntaje >= PlayerPrefs.GetInt(T3_valor) && puntaje < PlayerPrefs.GetInt(T2_valor))
        {
            //guardar tabla anterior menos el #5 que quedara eliminado y evadiendo los #1 y #2
            int puesto3_valor = PlayerPrefs.GetInt(T3_valor);
            string puesto3_nombre = PlayerPrefs.GetString(T3_nombre);
            string puesto3_cancion = PlayerPrefs.GetString(T3_cancion);

            int puesto4_valor = PlayerPrefs.GetInt(T4_valor);
            string puesto4_nombre = PlayerPrefs.GetString(T4_nombre);
            string puesto4_cancion = PlayerPrefs.GetString(T4_cancion);

            //guardar nuevos valores con el nuevo #3 hacia abajo
            PlayerPrefs.SetInt(T3_valor, puntaje);
            PlayerPrefs.SetString(T3_nombre, nombreRecord); //puesto que se actualiza #3
            PlayerPrefs.SetString(T5_cancion, nombreCancion);

            PlayerPrefs.SetInt(T4_valor, puesto3_valor);
            PlayerPrefs.SetString(T4_nombre, puesto3_nombre);
            PlayerPrefs.SetString(T4_cancion, puesto3_cancion);

            PlayerPrefs.SetInt(T5_valor, puesto4_valor);
            PlayerPrefs.SetString(T5_nombre, puesto4_nombre);
            PlayerPrefs.SetString(T5_cancion, puesto4_cancion);
        }

        //ReCalcular orden de la tabla si es mayor al #4 actual y menor que el #3
        if (puntaje >= PlayerPrefs.GetInt(T4_valor) && puntaje < PlayerPrefs.GetInt(T3_valor))
        {
            //guardar tabla anterior menos el #5 que quedara eliminado y evadiendo los #1, #2 y #3
            int puesto4_valor = PlayerPrefs.GetInt(T4_valor);
            string puesto4_nombre = PlayerPrefs.GetString(T4_nombre);
            string puesto4_cancion = PlayerPrefs.GetString(T4_cancion);

            //guardar nuevos valores con el nuevo #4 hacia abajo
            PlayerPrefs.SetInt(T4_valor, puntaje);
            PlayerPrefs.SetString(T4_nombre, nombreRecord); //puesto que se actualiza #4
            PlayerPrefs.SetString(T4_cancion, nombreCancion);

            PlayerPrefs.SetInt(T5_valor, puesto4_valor);
            PlayerPrefs.SetString(T5_nombre, puesto4_nombre);
            PlayerPrefs.SetString(T5_cancion, puesto4_cancion);
        }

        //ReCalcular orden de la tabla si es mayor al #5 actual y menor que el #4
        if (puntaje >= PlayerPrefs.GetInt(T5_valor) && puntaje < PlayerPrefs.GetInt(T4_valor))
        {
            //guardar el nuevo valor con el nuevo #5, no es necesario guardar tabla anterior
            PlayerPrefs.SetInt(T5_valor, puntaje);
            PlayerPrefs.SetString(T5_nombre, nombreRecord); //puesto que se actualiza #5
            PlayerPrefs.SetString(T5_cancion, nombreCancion);
        }
    }

    public void ActualizarTablaUI()
    {
        ///tabla especifica por cancion
        U1_nombre.text = jugadores[0];
        U1_valor.text = puntajes[0].ToString();
        //U1_cancion.text = "-";

        U2_nombre.text = jugadores[1];
        U2_valor.text = puntajes[1].ToString();
        //U2_cancion.text = "-";

        U3_nombre.text = jugadores[2];
        U3_valor.text = puntajes[2].ToString();
        //U3_cancion.text = "-";

        U4_nombre.text = jugadores[3];
        U4_valor.text = puntajes[3].ToString();
        //U4_cancion.text = "-";

        U5_nombre.text = jugadores[4];
        U5_valor.text = puntajes[4].ToString();
        //U5_cancion.text = "-";


        ///tabla general
        /*U1_nombre.text = PlayerPrefs.GetString(T1_nombre);
        U1_valor.text = PlayerPrefs.GetInt(T1_valor).ToString();
        U1_cancion.text = PlayerPrefs.GetString(T1_cancion);

        U2_nombre.text = PlayerPrefs.GetString(T2_nombre);
        U2_valor.text = PlayerPrefs.GetInt(T2_valor).ToString();
        U2_cancion.text = PlayerPrefs.GetString(T2_cancion);

        U3_nombre.text = PlayerPrefs.GetString(T3_nombre);
        U3_valor.text = PlayerPrefs.GetInt(T3_valor).ToString();
        U3_cancion.text = PlayerPrefs.GetString(T3_cancion);

        U4_nombre.text = PlayerPrefs.GetString(T4_nombre);
        U4_valor.text = PlayerPrefs.GetInt(T4_valor).ToString();
        U4_cancion.text = PlayerPrefs.GetString(T4_cancion);

        U5_nombre.text = PlayerPrefs.GetString(T5_nombre);
        U5_valor.text = PlayerPrefs.GetInt(T5_valor).ToString();
        U5_cancion.text = PlayerPrefs.GetString(T5_cancion);*/
    }
}