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
        NavMeshAgente.destination = PosOgro.position;
        //Debug.DrawRay(transform.position, Ogro.transform.forward);
	}
}
