using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void BotonUnJugador(){
        SceneManager.LoadScene("UnJugador");
    }

    public void Multijugador()
    {
        SceneManager.LoadScene("Multijugador");
    }

    public void BotonQuit()
    {
        Debug.Log("Quitamos la app");
        Application.Quit();
    }
}
