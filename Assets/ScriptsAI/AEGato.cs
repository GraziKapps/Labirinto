using UnityEngine;
using System.Collections;

public class AEGato : MonoBehaviour {

    public NavMeshAgent NavMeshAgente;
    public Transform NextPos;

    // Use this for initialization
    void Start()
    {
        NavMeshAgente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgente.destination = NextPos.position; /* Encontra o melhor caminho para chegar ao destino*/
        //Debug.DrawRay(transform.position, Ogro.transform.forward);
    }
}
