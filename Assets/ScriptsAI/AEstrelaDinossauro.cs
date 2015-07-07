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
<<<<<<< HEAD
        NavMeshAgente.destination = PosOgro.position; /* Encontra o melhor caminho para chegar ao destino*/
=======
        NavMeshAgente.destination = PosOgro.position;
>>>>>>> d2c1a7ce7af471b5bacf06c18635fd2cb53bd8e8
>>>>>>> e5002d468f3727f942c85f031b56164a69a17e3b
        //Debug.DrawRay(transform.position, Ogro.transform.forward);
	}
}
