using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemigo : MonoBehaviour
{
    public Transform Objetivo;
    public float Velocidad;
    public NavMeshAgent IA;

    void Update()
    {
        IA.speed = Velocidad;
        IA.SetDestination(Objetivo.position);
    }

    private void OnCollisionEnter(Collision collision)
{Debug.Log("COlisiona ");
    if (collision.gameObject.CompareTag("Player"))
    {
        Debug.Log("COlisiona jugador");
        // Destruir este objeto cuando colisiona con el jugador
        Destroy(this.gameObject);
    }
}
}
 