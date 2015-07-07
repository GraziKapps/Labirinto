using UnityEngine;
using System.Collections;

public class MEDino : MonoBehaviour {

    EstadoDino estado;
    GameObject Ogro;
    public NavMeshAgent NavMeshAgente;

    public bool veOgro;

    public float dis;

	// Use this for initialization
	void Start () {

        estado = GetComponent<EstadoDino>();
        NavMeshAgente = GetComponent<NavMeshAgent>();
        Ogro = GameObject.Find("monster1AnimsNormal");
        veOgro = false;
        
          
	}
	
	// Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        dis = Vector3.Distance(transform.position, Ogro.transform.position);

        /*****************************************************/
        /* Vê Jogador                                        */
        /*****************************************************/

        // lança um raio a partir do ogro
        // Se o raio encontrar o Ogro seta veOgro para verdadeiro

        if (Physics.Raycast(transform.position, transform.forward, out hit, 20F))
        {
            Debug.Log("FollowPath: VENDO OBJETO - " + hit.transform.gameObject.ToString());

            if (hit.transform.gameObject.tag == "Ogro")
            {
                Debug.Log("VIU JOGADOR");
                

                dis = Vector3.Distance(transform.position, Ogro.transform.position);

                if (Vector3.Distance(transform.position, Ogro.transform.position) <= 20)
                {

                    estado.Perseguindo = true;
                    estado.Andando = false;
                    estado.Parado = false;



                    NavMeshAgente.speed = 3.5f;

                    veOgro = true;
                }
            }
        }

        /*****************************************************/
        /* Perde Jogador                                     */
        /*****************************************************/

       // Debug.DrawRay(transform.position, Ogro.transform.forward);

        if (Vector3.Distance(transform.position, Ogro.transform.position) >= 15 && veOgro == true)
        {

            estado.Perseguindo = false;
            estado.Andando = false;
            estado.Parado = true;

            Debug.Log("PERDEU JOGADOR");

            NavMeshAgente.speed = 2;

            veOgro = false;
        }
    }
}
