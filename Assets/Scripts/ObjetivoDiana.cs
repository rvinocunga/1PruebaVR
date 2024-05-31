using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoDiana : MonoBehaviour
{
    public float speedMovement = 2f;
    private bool movingRight = true; // Variable para rastrear la dirección del movimiento

    public int valor;
    public AudioClip sonidoRomper;

    void Update()
    {
        MoveObject();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Misil"))
        {
            GameManager.Instance.SumarPuntos(valor);
            AudioManager.Instance.ReproducirSonido(sonidoRomper);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pared"))  
        {
            movingRight = !movingRight; // Invertir dirección
            //Debug.Log("Colisiona con pared");
        }
    }

    void MoveObject()
    {
        Vector3 movementDirection = movingRight ? Vector3.right : Vector3.left;
        transform.position += movementDirection * speedMovement * Time.deltaTime;
    }
}
