﻿using UnityEngine;
using System.Collections;

public class EstadoDino : MonoBehaviour {

    public float distancia;
    public float tempoParada;

    AEstrelaDinossauro AEDino;
    GameObject Ogro;
<<<<<<< HEAD
    public GameObject Dino;
=======
<<<<<<< HEAD
    public GameObject Dino;
=======
<<<<<<< HEAD
    public GameObject Dino;
=======
    GameObject Dino;
>>>>>>> e5002d468f3727f942c85f031b56164a69a17e3b
>>>>>>> 1b9270447642adda666c723648e6098531c88141
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f
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
<<<<<<< HEAD
        animacao = Dino.GetComponent<Animation>();
        Ogro = GameObject.Find("monster1AnimsNormal");
=======
<<<<<<< HEAD
        animacao = Dino.GetComponent<Animation>();
        Ogro = GameObject.Find("monster1AnimsNormal");
=======
<<<<<<< HEAD
        animacao = Dino.GetComponent<Animation>();
        Ogro = GameObject.Find("monster1AnimsNormal");
=======
        Ogro = GameObject.Find("monster1AnimsNormal");
        Dino = GameObject.Find("Allosaurus_01");
        animacao = Dino.GetComponent<Animation>();
>>>>>>> e5002d468f3727f942c85f031b56164a69a17e3b
>>>>>>> 1b9270447642adda666c723648e6098531c88141
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f

        tempoParada = 0;

	}
	
	// Update is called once per frame
	void Update () {

        /******************************************/
        /* Estado Andando                         */
        /******************************************/
        

        if (Andando)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> e5002d468f3727f942c85f031b56164a69a17e3b
>>>>>>> 1b9270447642adda666c723648e6098531c88141
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f
            AEDino.NavMeshAgente.Resume(); // continua o caminho

            animacao.Play("Allosaurus_Walk"); // animação de andar

            if (wp <= wayPoint.Length - 1)
            {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f
                AEDino.NextPos = wayPoint[wp].transform; // Segue para o próximo waypoint

                if (Vector3.Distance(transform.position, wayPoint[wp].transform.position) <= 1.5) // Se a 1,5 metros do waypoint
                    wp++; // acrementa o waypoint
<<<<<<< HEAD
=======
=======
                AEDino.PosOgro = wayPoint[wp].transform; // Segue para o próximo waypoint

                if (Vector3.Distance(transform.position, wayPoint[wp].transform.position) <= 1.5) // Se a 1,5 metros do waypoint
                    wp++; // acrementa o waypoint
<<<<<<< HEAD
=======
=======
            AEDino.NavMeshAgente.Resume();

            animacao.Play("Allosaurus_Walk");

            if (wp <= wayPoint.Length - 1)
            {
                AEDino.PosOgro = wayPoint[wp].transform;

                distancia = Vector3.Distance(transform.position, wayPoint[wp].transform.position);

                if (Vector3.Distance(transform.position, wayPoint[wp].transform.position) <= 1.5)
                    wp++;
>>>>>>> d2c1a7ce7af471b5bacf06c18635fd2cb53bd8e8
>>>>>>> e5002d468f3727f942c85f031b56164a69a17e3b
>>>>>>> 1b9270447642adda666c723648e6098531c88141
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f
            }

            else
            {
<<<<<<< HEAD
                wp = 0; // inicia os waypoints
=======
<<<<<<< HEAD
                wp = 0; // inicia os waypoints
=======
<<<<<<< HEAD
                wp = 0; // inicia os waypoints
=======
<<<<<<< HEAD
                wp = 0; // inicia os waypoints
=======
                wp = 0;
>>>>>>> d2c1a7ce7af471b5bacf06c18635fd2cb53bd8e8
>>>>>>> e5002d468f3727f942c85f031b56164a69a17e3b
>>>>>>> 1b9270447642adda666c723648e6098531c88141
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f
            }

        }

        /******************************************/
        /* Estado Perceguindo                     */
        /******************************************/

        if(Perseguindo)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> e5002d468f3727f942c85f031b56164a69a17e3b
>>>>>>> 1b9270447642adda666c723648e6098531c88141
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f
            AEDino.NavMeshAgente.Resume(); // continua o caminho

            animacao.Play("Allosaurus_Run"); // animação de correr

<<<<<<< HEAD
            AEDino.NextPos = Ogro.transform; // segue o ogro
=======
<<<<<<< HEAD
            AEDino.NextPos = Ogro.transform; // segue o ogro
=======
            AEDino.PosOgro = Ogro.transform; // segue o ogro
<<<<<<< HEAD
=======
=======
            AEDino.NavMeshAgente.Resume();

            animacao.Play("Allosaurus_Run");

            AEDino.PosOgro = Ogro.transform;
>>>>>>> d2c1a7ce7af471b5bacf06c18635fd2cb53bd8e8
>>>>>>> e5002d468f3727f942c85f031b56164a69a17e3b
>>>>>>> 1b9270447642adda666c723648e6098531c88141
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f
        }

        /******************************************/
        /* Estado Parado                          */
        /******************************************/

        if(Parado)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> e5002d468f3727f942c85f031b56164a69a17e3b
>>>>>>> 1b9270447642adda666c723648e6098531c88141
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f
            tempoParada += Time.deltaTime; // começa a contar o tempo

            AEDino.NavMeshAgente.Stop(); // pausa o trajeto

            animacao.Play("Allosaurus_IdleBellow"); // animação de parado

            if(tempoParada >= 15) // após 15 segundos
            {
                tempoParada = 0; // tempo é zerado
                Parado = false;
                Andando = true; // volta a seguir os waypoints
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
            tempoParada += Time.deltaTime;

            AEDino.NavMeshAgente.Stop();

            animacao.Play("Allosaurus_IdleBellow");

            if(tempoParada >= 15)
            {
                tempoParada = 0;
                Parado = false;
                Andando = true;
>>>>>>> d2c1a7ce7af471b5bacf06c18635fd2cb53bd8e8
>>>>>>> e5002d468f3727f942c85f031b56164a69a17e3b
>>>>>>> 1b9270447642adda666c723648e6098531c88141
>>>>>>> d2f09d1e0a632a9c536cc599c06572e68b65673f
            }
        }
	
	}
}
