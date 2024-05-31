using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton : MonoBehaviour
{
    public Timer timerScript; // Referencia al script del temporizador
    public GameObject cristal;
    public GameObject objetivos;
     public AudioClip inicioRonda;

    // Si el personaje toca el cubo
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cristal.SetActive(false); // oculta el cristal
            objetivos.SetActive(true); // muestra las dianas
            timerScript.StartTimer(); // empieza el temporizador
            AudioManager.Instance.Stop(); // para el soundtrack

            AudioManager.Instance.ReproducirSonido(inicioRonda); // reproduce el sonido de ronda
            this.gameObject.SetActive(false); // oculta la placa
        }
    }
        
    public void acabaTemporizador()
    {
        cristal.SetActive(true); // muestra el cristal
        objetivos.SetActive(false); // oculta las dianas
        this.gameObject.SetActive(true); // vuelve a colocar la placa
        AudioManager.Instance.Stop(); // para el sonido de ronda

        // Esperar 5 segundos y luego cargar la escena "UnJugador"
         Invoke("CargarEscenaUnJugador", 5f);
    }

    void CargarEscenaUnJugador()
    {
        SceneManager.LoadScene("UnJugador");
    }
}
