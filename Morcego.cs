using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morcego : MonoBehaviour {

	//variaveis
	[SerializeField] private float velMorcego,velDescendo;      // Velocidade de movimento e descida do morcego
	[SerializeField] private bool Direita, Esquerda;			// bool se pode ir para direita ou esquerda
	[SerializeField] private float distMovimento;				// distancia até onde obj pode ir
	[SerializeField] private GameObject objExplodi;				//prefab da explosãp
	private int aux;											// auxilar quando iniciar jogo pega random se vai para Dir / Esq

	// Use this for initialization
	void Start () {

		//incia valor aleatorio para move morcego para Dir ou Esq
		aux =Random.Range (0, 2);
		if (aux == 0) {
		
			Direita = true;
		} else {
		
			Esquerda = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//metodo move para Dir /Esq / Baixo
		DireitaEsquerda ();


	}
	//Metodo faz mover morcego quando jogo inicia
	void DireitaEsquerda(){
	
		if(UiManager.instance.ComecouJogo){

			if (Direita) {

				transform.Translate (velMorcego * Time.deltaTime, velDescendo * Time.deltaTime, 0);
				if (transform.position.x >= distMovimento) {

					Direita = false;
					Esquerda = true;
				}
			} else {

				if (Esquerda) {

					transform.Translate (-velMorcego * Time.deltaTime,velDescendo * Time.deltaTime,0);
				}
				if (transform.position.x <= -distMovimento) {

					Esquerda = false;
					Direita = true;
				}
			}
		}

	}
	//Trigger que verificar se tiro encostou no morcego
	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.CompareTag ("Tiro")) {

			//cria efeito de particula
			GameObject inst = Instantiate (objExplodi,transform.position,Quaternion.identity);
			//ganha pontos
			UiManager.instance.pontos += 10;
			//destroi morcego
			Destroy (this.gameObject);
		}
	}
}
