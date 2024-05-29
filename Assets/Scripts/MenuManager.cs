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
        // Se tendría que abrir una nueva interfaz para 
        // que elija si crear partida o ver las que están creada

        SceneManager.LoadScene("Demo");
    }

    public void BotonQuit()
    {
        Debug.Log("Quitamos la app");
        Application.Quit();
    }
}
