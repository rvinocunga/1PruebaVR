using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Boton scriptBoton;
    public FirebaseDB scriptDB;
    public float timer = 0;
    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI textAviso;
    private bool isRunning = false;

    void Update()
    {
        if (isRunning)
        {
            textAviso.enabled = false; // oculta las instrucciones
            timer -= Time.deltaTime;
            timer = Mathf.Max(timer, 0); // temporizador no caiga por debajo de 0
            textTimer.text = timer.ToString("f2"); // visualiza en el ui el tiempo restante

            if (timer <= 0)
            {
                timer = 0;

                // bbdd
                scriptDB.enviarPuntuacion();

                // vuelve a la placa
                scriptBoton.acabaTemporizador();
                
                isRunning = false;
            }
        }
    }

    // Método para iniciar el temporizador
    public void StartTimer()
    {
        isRunning = true;
    }

    
}
