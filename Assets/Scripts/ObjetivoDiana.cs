using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoDiana : MonoBehaviour
{
    public float speedMovement = 2f;
    private bool movingRight = true; // para cambiar direccion

    public int valor;
    public AudioClip sonidoRomper;

    void Update()
    {
        MoveObject();
    }

    // ObjetivoDiana.cs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Misil"))
        {
            // llama al metodo de la instancia correspondiente 
            GameManager.Instance.SumarPuntos(valor);
            AudioManager.Instance.ReproducirSonido(sonidoRomper);
            this.gameObject.SetActive(false);
        }
    }

    // ObjetivoDiana.cs
    private void OnTriggerEnter(Collider other)
    {
        // si choca con tag Pared
        if (other.CompareTag("Pared"))  
        {
            movingRight = !movingRight; // Invertir dirección
        }
    }

    // metodo en Update()
    void MoveObject()
    {
        Vector3 movementDirection = movingRight ? Vector3.right : Vector3.left;
        transform.position += movementDirection * speedMovement * Time.deltaTime;
    }
}
