using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour {

	public static Canhao instance;

	//variaveis
	[SerializeField] private bool liberaTiro;          // bool pode atira
	[SerializeField] private bool aumenta, diminuir;   // bool para aumenta e diminuir valor eixo
	[SerializeField] private float giroCanhao;         // quanto canhão gira
	[SerializeField] private float velGiro,eixoGiro;   // velocidade movimento do do canhão e até onde eixo de giro vai
	[SerializeField] private GameObject Tiro;			// prefab do tiro
	[SerializeField] private float intervaloTiro = -1;  // intervalo para atirar
	[SerializeField] Transform localTiro;				//local onde tiro vai nasce

	// variavel que vai pega giro do tiro
	public float anguloTiro;

	// Use this for initialization
	void Start () {

		instance = this;
		//peganddo local do tiro
		localTiro = GameObject.Find ("Tiro").GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {

		//inicio de jogo
		StartGame ();

		//intervalo de tiros
		if(intervaloTiro <= 0){

			liberaTiro = true;
			UiManager.instance.txtRecarregando.gameObject.SetActive (false);

		}else{
			liberaTiro = false;
			UiManager.instance.txtRecarregando.gameObject.SetActive (true);
			UiManager.instance.txtRecarregando.text = intervaloTiro.ToString ("#0.0");
			intervaloTiro -= Time.deltaTime;
		}

	}
	//metodo inicio de jogo e fazendo canhão gira
	void StartGame(){
	
		if (UiManager.instance.ComecouJogo) {

			if (aumenta) {

				giroCanhao += velGiro * Time.deltaTime;
				if (giroCanhao >= eixoGiro) {

					aumenta = false;
					diminuir = true;
				}
			} else {

				giroCanhao -= velGiro * Time.deltaTime;
				if (giroCanhao <= -eixoGiro) {

					diminuir = false;
					aumenta = true;
				}
			}
		}
		transform.localRotation = Quaternion.Euler (0,0,giroCanhao );
	}
	//metodo para atirar
	public void Atirando(){
			
		if (liberaTiro && UiManager.instance.ComecouJogo && Time.timeScale == 1) {
		
			anguloTiro = giroCanhao;
			GameObject inst = Instantiate (Tiro, localTiro.position, Quaternion.Euler(0,0,giroCanhao));
			intervaloTiro = 1.3f;
		}
	}
}
