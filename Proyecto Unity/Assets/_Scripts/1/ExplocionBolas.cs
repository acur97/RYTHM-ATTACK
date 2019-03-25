using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplocionBolas : MonoBehaviour {

    public float radioBola;
    public float fuerzaExplocion;

	public void Explotar()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioBola);

        foreach (Collider ObjetosCercanos in colliders)
        {
            Rigidbody rb = ObjetosCercanos.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(fuerzaExplocion, transform.position, radioBola);
            }
        }
    }
}
