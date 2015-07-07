using UnityEngine;
using System.Collections;

public class MEGato : MonoBehaviour {

    EstadoGato estado;
    GameObject Ogro;
    public NavMeshAgent NavMeshAgente;

    public bool veOgro;

    public float dis;

    // Use this for initialization
    void Start()
    {

        estado = GetComponent<EstadoGato>();
        NavMeshAgente = GetComponent<NavMeshAgent>();
        Ogro = GameObject.Find("monster1AnimsNormal");
        veOgro = false;


    }

    // Update is called once per frame
    void Update()
    {

         dis = Vector3.Distance(transform.position, Ogro.transform.position);

        /*****************************************************/
        /* Se Ogro chega perto                               */
        /*****************************************************/


        dis = Vector3.Distance(transform.position, Ogro.transform.position);

        if (Vector3.Distance(transform.position, Ogro.transform.position) <= 7 && veOgro == false)
        {

            estado.Fugindo = true;
            estado.Andando = false;
            estado.Parado = false;
            
            veOgro = true;
        }

        /*****************************************************/
        /* Se ogro se afasta                                 */
        /*****************************************************/

        if (Vector3.Distance(transform.position, Ogro.transform.position) > 4 && veOgro == true)
        {

            estado.Fugindo = false;
            estado.Andando = true;
            estado.Parado = false;

            veOgro = false;
        }
    }
}
