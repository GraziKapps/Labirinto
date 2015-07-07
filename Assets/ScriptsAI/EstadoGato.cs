using UnityEngine;
using System.Collections;

public class EstadoGato : MonoBehaviour {

    public float distancia;
    public float tempoParada;

    AEGato AGato;
    GameObject Ogro;
    public GameObject Gato;
    Animation animacao;

    public bool Andando;
    public bool Fugindo;
    public bool Parado;

    public int wp;
    public GameObject[] wayPoint;
    public GameObject wayPointFuga;


    // Use this for initialization
    void Start()
    {
        Andando = true;
        Fugindo = false;
        Parado = false;

        wp = 0;

        AGato = GetComponent<AEGato>();
        animacao = Gato.GetComponent<Animation>();
        Ogro = GameObject.Find("monster1AnimsNormal");

        tempoParada = 0;

    }

    // Update is called once per frame
    void Update()
    {

        /******************************************/
        /* Estado Andando                         */
        /******************************************/


        if (Andando)
        {
            tempoParada += Time.deltaTime;

            AGato.NavMeshAgente.Resume(); // continua o caminho

            AGato.NavMeshAgente.speed = 0.5F;
            AGato.NavMeshAgente.acceleration = 0.2F;

            animacao.Play("Walk"); // animação de andar

            if (tempoParada <= 15)
            {
                if (wp <= wayPoint.Length - 1)
                {
                    AGato.NextPos = wayPoint[wp].transform; // Segue para o próximo waypoint

                    distancia = Vector3.Distance(transform.position, wayPoint[wp].transform.position);
                    if (Vector3.Distance(transform.position, wayPoint[wp].transform.position) <= 0.2) // Se a 1,5 metros do waypoint
                       wp = Random.Range(0,3); // acrementa o waypoint
                }
            }

            else
            {
                tempoParada = 0; // tempo é zerado
                Parado = true;
                Andando = false; // volta a seguir os waypoints
            }

        }

        /******************************************/
        /* Estado Perceguindo                     */
        /******************************************/

        if (Fugindo)
        {
            AGato.NavMeshAgente.Resume(); // continua o caminho

            AGato.NavMeshAgente.speed = 6;
            AGato.NavMeshAgente.acceleration = 0.5F;

            animacao.Play("Run"); // animação de correr

            AGato.NextPos = wayPointFuga.transform; // segue o ogro

             if (Vector3.Distance(transform.position, wayPointFuga.transform.position) <= 0.2)
             {
                 Parado = true;
                 Andando = false;
                 Fugindo = false;
             }
        }

        /******************************************/
        /* Estado Parado                          */
        /******************************************/

        if (Parado)
        {
            tempoParada += Time.deltaTime; // começa a contar o tempo

            AGato.NavMeshAgente.Stop(); // pausa o trajeto
            AGato.NavMeshAgente.acceleration = 0.2F;

            if(tempoParada < 4)
                animacao.Play("IdleSit"); // animação de parado

            if (tempoParada >= 4 && tempoParada < 7)
                animacao.Play("Idle"); // animação de parado

            if (tempoParada <= 7 && tempoParada < 11)
                animacao.Play("IdleSit"); // animação de parado

            if (tempoParada >= 11 && tempoParada < 15)
                animacao.Play("Idle"); // animação de parado

            if (tempoParada >= 15) // após 15 segundos
            {
                tempoParada = 0; // tempo é zerado
                Parado = false;
                Andando = true; // volta a seguir os waypoints
            }
        }

    }
}
