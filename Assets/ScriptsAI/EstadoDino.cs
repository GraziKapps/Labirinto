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
            AEDino.NavMeshAgente.Resume();

            animacao.Play("Allosaurus_Walk");

            if (wp <= wayPoint.Length - 1)
            {
                AEDino.PosOgro = wayPoint[wp].transform;

                distancia = Vector3.Distance(transform.position, wayPoint[wp].transform.position);

                if (Vector3.Distance(transform.position, wayPoint[wp].transform.position) <= 1.5)
                    wp++;
            }

            else
            {
                wp = 0;
            }

        }

        /******************************************/
        /* Estado Perceguindo                     */
        /******************************************/

        if(Perseguindo)
        {
            AEDino.NavMeshAgente.Resume();

            animacao.Play("Allosaurus_Run");

            AEDino.PosOgro = Ogro.transform;
        }

        /******************************************/
        /* Estado Parado                          */
        /******************************************/

        if(Parado)
        {
            tempoParada += Time.deltaTime;

            AEDino.NavMeshAgente.Stop();

            animacao.Play("Allosaurus_IdleBellow");

            if(tempoParada >= 15)
            {
                tempoParada = 0;
                Parado = false;
                Andando = true;
            }
        }
	
	}
}
