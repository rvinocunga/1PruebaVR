using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoDiana : MonoBehaviour
{

    public int valor;
    public AudioClip sonidoRomper;

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Misil"))
        {
            GameManager.Instance.SumarPuntos(valor);
            AudioManager.Instance.ReproducirSonido(sonidoRomper);
            this.gameObject.SetActive(false);
        }
    }
}
