using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemigo : MonoBehaviour
{
    public Transform Objetivo;
    public float Velocidad;
    public NavMeshAgent IA;
    
    public int damage;
    //public GameObject Player;

    // 
    void Update()
    {
        IA.speed = Velocidad;
        IA.SetDestination(Objetivo.position);
    }

    // para destruirlo
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Arma"))
    {
        Destroy(gameObject);
    }
}

}
 