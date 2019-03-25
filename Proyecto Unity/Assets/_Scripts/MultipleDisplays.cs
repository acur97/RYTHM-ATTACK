using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleDisplays : MonoBehaviour {

    //probar en un awake
	void Start ()
    {
        Debug.Log("Pantallas: " + Display.displays.Length);
        //Display.display[0] siempre es la primaria
        //Compruebe si existe mas de 1 pantalla y activela
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
            Debug.Log("Pantalla #2, Activada");
        }
	}
}