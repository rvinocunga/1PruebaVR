using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    public TextMeshProUGUI textTimer;
    private bool isRunning = false;

    void Update()
    {
        if (isRunning)
        {
            timer -= Time.deltaTime;
            timer = Mathf.Max(timer, 0); // Asegurarse de que el temporizador no caiga por debajo de 0
            textTimer.text = timer.ToString("f2");

            if (timer <= 0)
            {
                timer = 0;
                Debug.Log("Acabó el temporizador");
                //SceneManager.LoadScene("MenuPrincipal");
            }
        }
    }

    // Método para iniciar el temporizador
    public void StartTimer()
    {
        isRunning = true;
    }
}
