using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public Timer timerScript; // Referencia al script del temporizador

        // Si el personaje toca el cubo
        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            timerScript.StartTimer();
            Destroy(gameObject);
        }
    }
}
