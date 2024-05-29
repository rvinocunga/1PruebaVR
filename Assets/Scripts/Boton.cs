using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public Timer timerScript; // Referencia al script del temporizador
    public GameObject cristal;
    public GameObject objetivos;

        // Si el personaje toca el cubo
        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cristal.SetActive(false);
            objetivos.SetActive(true);
            timerScript.StartTimer();
            this.gameObject.SetActive(false);
        }
    }
        
    public void acabaTemporizador()
    {
        cristal.SetActive(true);
        objetivos.SetActive(false);
        this.gameObject.SetActive(true);
    }
}
