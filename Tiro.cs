using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {

	//variaveis
	[SerializeField] private float velTiro;          //velocidade do tiro
	[SerializeField] private float tempoVidaTiro;    // tempo de vida que tira vai durar
	[SerializeField] private GameObject fogo;        // prefab de fogo

	// Update is called once per frame
	void Update () {

		//movendo o tiro
		transform.Translate (0,velTiro * Time.deltaTime,0);
		//metodo morte do tiro
		MorteTiro ();
	}
	//metodo morte do tiro se não acerta nada
	void MorteTiro(){
	
		tempoVidaTiro -= Time.deltaTime;
		if (tempoVidaTiro <= 0) {
		
			Destroy (this.gameObject);
		}
	}
	//metodo que verificar se tiro encostou em outro objeto
	void OnTriggerEnter2D(Collider2D col){
	
		if (col.gameObject.CompareTag ("inimigo")) {

			Destroy (this.gameObject);
		}
		if(col.gameObject.CompareTag("Pedra")){

			GameObject inst = Instantiate (fogo, transform.position, Quaternion.Euler(0,0,Canhao.instance.anguloTiro));
			Destroy (this.gameObject);
		}
	}
}
