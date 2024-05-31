using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;
using Firebase.Database;

//https://www.youtube.com/watch?v=Fzjmv6PBK4U
public class FirebaseDB : MonoBehaviour
{
    DatabaseReference reference;
    public TextMeshProUGUI ranking;

    string nombreUnico = System.Guid.NewGuid().ToString();

    // Start is called before the first frame update
    void Start()
    {
       // RECUPERA LOS JUGADORES Y PUNTUACIONES

       //Debug.Log("Start db");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        recuperarPuntuaciones();
    }

    public void recuperarPuntuaciones()
    {
        Debug.Log("recuperar PUNTUACIONES");
        reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error al cargar datos de jugadores: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot playersSnapshot = task.Result;

                // almacenar todo el texto del ranking
                string rankingText = "";

                // Iterar sobre cada jugador
                foreach (DataSnapshot playerSnapshot in playersSnapshot.Children)
                {
                    string jugador = playerSnapshot.Key; // Obtener el nombre 

                    // Obtener la puntuación 
                    int puntuacion = Convert.ToInt32(playerSnapshot.Child("Puntuacion").Value);

                    // nombre del jugador y su puntuación
                    string entry = "Jugador: " + jugador + ", Puntuacion: " + puntuacion;

                    // Concatenar la entrada al texto del ranking, separado por un salto de línea
                    rankingText += entry + "\n";
                }

                // Asignar el texto completo del ranking al objeto TextMeshProUGUI
                ranking.text = rankingText;
                Debug.Log(rankingText);
            }
        });
    }


    public void enviarPuntuacion()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        //Debug.Log("Entra al db.enviarPuntuacion: ");
        reference.Child("Vinocunga").Child("Puntuacion").SetValueAsync(GameManager.Instance.PuntosTotales.ToString()).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error al enviar datos a Firebase: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Datos enviados correctamente a Firebase");
            }
        });
    }
}
