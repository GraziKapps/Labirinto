using UnityEngine;
using System.Collections;

public class EstadoDino : MonoBehaviour {

    public float distancia;
    public float tempoParada;

    AEstrelaDinossauro AEDino;
    GameObject Ogro;
    GameObject Dino;
    Animation animacao;

    public bool Andando;
    public bool Perseguindo;
    public bool Parado;

    public int wp;
    public GameObject[] wayPoint;


	// Use this for initialization
	void Start () {
        Andando = true;
        Perseguindo = false;
        Parado = false;

        wp = 0;

        AEDino = GetComponent<AEstrelaDinossauro>();
        Ogro = GameObject.Find("monster1AnimsNormal");
        Dino = GameObject.Find("Allosaurus_01");
        animacao = Dino.GetComponent<Animation>();

        tempoParada = 0;

	}
	
	// Update is called once per frame
	void Update () {

        /******************************************/
        /* Estado Andando                         */
        /******************************************/
        

        if (Andando)
        {
            AEDino.NavMeshAgente.Resume(); // continua o caminho

            animacao.Play("Allosaurus_Walk"); // animação de andar

            if (wp <= wayPoint.Length - 1)
            {
                AEDino.PosOgro = wayPoint[wp].transform; // Segue para o próximo waypoint

                if (Vector3.Distance(transform.position, wayPoint[wp].transform.position) <= 1.5) // Se a 1,5 metros do waypoint
                    wp++; // acrementa o waypoint
            }

            else
            {
                wp = 0; // inicia os waypoints
            }

        }

        /******************************************/
        /* Estado Perceguindo                     */
        /******************************************/

        if(Perseguindo)
        {
            AEDino.NavMeshAgente.Resume(); // continua o caminho

            animacao.Play("Allosaurus_Run"); // animação de correr

            AEDino.PosOgro = Ogro.transform; // segue o ogro
        }

        /******************************************/
        /* Estado Parado                          */
        /******************************************/

        if(Parado)
        {
            tempoParada += Time.deltaTime; // começa a contar o tempo

            AEDino.NavMeshAgente.Stop(); // pausa o trajeto

            animacao.Play("Allosaurus_IdleBellow"); // animação de parado

            if(tempoParada >= 15) // após 15 segundos
            {
                tempoParada = 0; // tempo é zerado
                Parado = false;
                Andando = true; // volta a seguir os waypoints
            }
        }
	
	}
}
