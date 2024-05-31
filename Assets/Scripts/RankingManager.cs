using UnityEngine;
using TMPro;
using Firebase.Database;
using System.Collections.Generic;
using System;

public class RankingManager : MonoBehaviour
{
    public TextMeshProUGUI textRanking;
    DatabaseReference reference;

    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        // Llamar a una función para cargar los datos del ranking y actualizar el TextMeshProUGUI
        ActualizarRanking();
    }

    void ActualizarRanking()
    {
        reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error al cargar datos de jugadores: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot playersSnapshot = task.Result;

                // Crear una lista para almacenar las puntuaciones de los jugadores
                List<string> ranking = new List<string>();

                // Iterar sobre cada jugador
                foreach (DataSnapshot playerSnapshot in playersSnapshot.Children)
                {
                    string jugador = playerSnapshot.Key; // Obtener el nombre del jugador
                    string puntuacion = playerSnapshot.Child("Puntuacion").Value.ToString(); // Obtener la puntuación del jugador

                    // Construir una cadena con el nombre del jugador y su puntuación
                    string entry = jugador + ": " + puntuacion;

                    // Agregar la entrada al ranking
                    ranking.Add(entry);
                }

                // Unir todas las entradas del ranking en una sola cadena de texto, separadas por saltos de línea
                string rankingText = string.Join("\n", ranking);

                // Actualizar el texto del TextMeshProUGUI con el ranking
                textRanking.text = rankingText;
            }
        });
    }
}
