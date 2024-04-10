using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoDiana : MonoBehaviour
{

    public int valor;
    public GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Misil"))
        {
            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
        }
    }
}
