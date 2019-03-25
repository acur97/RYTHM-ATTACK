using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeTabla : MonoBehaviour {

    public Text U1_nombre;
    public Text U1_valor;
    public Text U1_cancion;
    [Space]
    public Text U2_nombre;
    public Text U2_valor;
    public Text U2_cancion;
    [Space]
    public Text U3_nombre;
    public Text U3_valor;
    public Text U3_cancion;
    [Space]
    public Text U4_nombre;
    public Text U4_valor;
    public Text U4_cancion;
    [Space]
    public Text U5_nombre;
    public Text U5_valor;
    public Text U5_cancion;

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

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(T1_nombre))
        {
            PlayerPrefs.SetInt(T1_valor, 0);
            PlayerPrefs.SetString(T1_nombre, "----------");
            PlayerPrefs.SetString(T1_cancion, "----------");

            PlayerPrefs.SetInt(T2_valor, 0);
            PlayerPrefs.SetString(T2_nombre, "----------");
            PlayerPrefs.SetString(T2_cancion, "----------");

            PlayerPrefs.SetInt(T3_valor, 0);
            PlayerPrefs.SetString(T3_nombre, "----------");
            PlayerPrefs.SetString(T3_cancion, "----------");

            PlayerPrefs.SetInt(T4_valor, 0);
            PlayerPrefs.SetString(T4_nombre, "----------");
            PlayerPrefs.SetString(T4_cancion, "----------");

            PlayerPrefs.SetInt(T5_valor, 0);
            PlayerPrefs.SetString(T5_nombre, "----------");
            PlayerPrefs.SetString(T5_cancion, "----------");
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

    public void NombreDeRecord(string nombre)
    {
        nombreRecord = nombre;
    }

    public void NombreDeCancion(string nombre)
    {
        nombreCancion = nombre;
    }

    public void PreguntaRecord(int puntaje)
    {
        if (puntaje >= PlayerPrefs.GetInt(T1_valor))
        {
            Puntaje.SiRecord = true;
        }
        if (puntaje >= PlayerPrefs.GetInt(T2_valor) && puntaje < PlayerPrefs.GetInt(T1_valor))
        {
            Puntaje.SiRecord = true;
        }
        if (puntaje >= PlayerPrefs.GetInt(T3_valor) && puntaje < PlayerPrefs.GetInt(T2_valor))
        {
            Puntaje.SiRecord = true;
        }
        if (puntaje >= PlayerPrefs.GetInt(T4_valor) && puntaje < PlayerPrefs.GetInt(T3_valor))
        {
            Puntaje.SiRecord = true;
        }
        if (puntaje >= PlayerPrefs.GetInt(T5_valor) && puntaje < PlayerPrefs.GetInt(T4_valor))
        {
            Puntaje.SiRecord = true;
        }
    }

    public void NuevoPuntaje(int puntaje)
    {
        //Escribir valor de record de cancion si es mayor al anterior
        string RecordDeCancion = RecordPorCancion + nombreCancion;
        if (PlayerPrefs.HasKey(RecordDeCancion))
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
        }

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

    public void BorraKeys()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Reset PlayerPrefs");
        PlayerPrefs.SetInt(T1_valor, 0);
        PlayerPrefs.SetString(T1_nombre, "----------");
        PlayerPrefs.SetString(T1_cancion, "----------");

        PlayerPrefs.SetInt(T2_valor, 0);
        PlayerPrefs.SetString(T2_nombre, "----------");
        PlayerPrefs.SetString(T2_cancion, "----------");

        PlayerPrefs.SetInt(T3_valor, 0);
        PlayerPrefs.SetString(T3_nombre, "----------");
        PlayerPrefs.SetString(T3_cancion, "----------");

        PlayerPrefs.SetInt(T4_valor, 0);
        PlayerPrefs.SetString(T4_nombre, "----------");
        PlayerPrefs.SetString(T4_cancion, "----------");

        PlayerPrefs.SetInt(T5_valor, 0);
        PlayerPrefs.SetString(T5_nombre, "----------");
        PlayerPrefs.SetString(T5_cancion, "----------");
    }
}
