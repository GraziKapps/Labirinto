using UnityEngine;
using System.Collections;

public class AEstrelaDinossauro : MonoBehaviour {

    public NavMeshAgent NavMeshAgente;
<<<<<<< HEAD
    public Transform NextPos;
=======
<<<<<<< HEAD
    public Transform NextPos;
=======
<<<<<<< HEAD
    public Transform NextPos;
=======
    public Transform PosOgro;
>>>>>>> 1b9270447642adda666c723648e6098531c88141
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f
>>>>>>> 7b96ceb962d88bca7ede30535adaaa2572e2620e

	// Use this for initialization
	void Start () {
        NavMeshAgente = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        NavMeshAgente.destination = NextPos.position; /* Encontra o melhor caminho para chegar ao destino*/
=======
<<<<<<< HEAD
        NavMeshAgente.destination = NextPos.position; /* Encontra o melhor caminho para chegar ao destino*/
=======
<<<<<<< HEAD
        NavMeshAgente.destination = NextPos.position; /* Encontra o melhor caminho para chegar ao destino*/
=======
<<<<<<< HEAD
        NavMeshAgente.destination = PosOgro.position; /* Encontra o melhor caminho para chegar ao destino*/
=======
<<<<<<< HEAD
        NavMeshAgente.destination = PosOgro.position; /* Encontra o melhor caminho para chegar ao destino*/
=======
        NavMeshAgente.destination = PosOgro.position;
>>>>>>> d2c1a7ce7af471b5bacf06c18635fd2cb53bd8e8
>>>>>>> e5002d468f3727f942c85f031b56164a69a17e3b
>>>>>>> 1b9270447642adda666c723648e6098531c88141
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f
>>>>>>> 7b96ceb962d88bca7ede30535adaaa2572e2620e
        //Debug.DrawRay(transform.position, Ogro.transform.forward);
	}
}
