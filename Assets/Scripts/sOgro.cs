using UnityEngine;
using System.Collections;

public class sOgro : MonoBehaviour {

    DadosOgro dadosOgro;

    float posX; // posição do texto
    float posY; // posição do texto

    float alturaTexto; // altura do botão
    float larguraTexto; // largura do botão

    Collision colisao;
    public bool colGatinho;
    public float dis;
	// Use this for initialization
	void Start () {

        alturaTexto = 30;
        larguraTexto = 100;

        posX = Screen.width - (larguraTexto) - 5; // Screen.width = largura do monitor
        posY = Screen.height / 2 - Screen.height / 2 + alturaTexto/2; // Screen.height = altura do monitor

        dadosOgro = GetComponent<DadosOgro>();

        colGatinho = false;

	}
	
	// Update is called once per frame
	void Update () {
	
        if(colGatinho == true && Vector3.Distance(transform.position, colisao.gameObject.transform.position) <= 1)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Se a tecla 'E' for pressionada
            {
                dadosOgro.gatinhos++;
                Destroy(colisao.gameObject);
            }
        }
	}

    /********************************/
    /* Verifica Colisao             */
    /********************************/

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.ToString());

        /* Colisão com Dinossauro */

        if(col.gameObject.tag == "Dinossauro") // Se houver colisão com um dinossauro
        {
            dadosOgro.vida--; // perde uma vida
        }

        /* Colisão com Gatinho */

        if (col.gameObject.tag == "Gatinho") // Se houver colisão com um dinossauro
        {
            colGatinho = true;
            colisao = col;
        }

        if (col.gameObject.tag != "Gatinho") // Se houver colisão com um dinossauro
        {
            colGatinho = false;
        }
    }

    /********************************/
    /* Dados na Tela                */
    /********************************/

    void OnGUI()
    {
        
        GUI.Box(new Rect(posX, posY, larguraTexto, alturaTexto), "Gatinhos: " + dadosOgro.gatinhos); // Escreve em uma caixa na tela
                   
        GUI.Box(new Rect(posX, posY + alturaTexto, larguraTexto, alturaTexto), "Vida: " + dadosOgro.vida); // Escreve em uma caixa na tela

    }
}
