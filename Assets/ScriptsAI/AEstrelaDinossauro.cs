using UnityEngine;
using System.Collections;

public class AEstrelaDinossauro : MonoBehaviour {

    public NavMeshAgent NavMeshAgente;
    public Transform PosOgro;

	// Use this for initialization
	void Start () {
        NavMeshAgente = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        NavMeshAgente.destination = PosOgro.position; /* Encontra o melhor caminho para chegar ao destino*/
=======
        NavMeshAgente.destination = PosOgro.position;
>>>>>>> d2c1a7ce7af471b5bacf06c18635fd2cb53bd8e8
        //Debug.DrawRay(transform.position, Ogro.transform.forward);
	}
}
