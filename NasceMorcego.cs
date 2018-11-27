using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NasceMorcego : MonoBehaviour {

	//variaveis
	[SerializeField] private float intervaloNasce;                      	//Intervalo para nasce morcego
	[SerializeField] private Transform ponto01, ponto02,ponto03;			// Os Transforms que vai pega linha onde nasce os morcegos
	[SerializeField] private GameObject objMorcego;							//prefab do morcego
	// Use this for initialization
	void Start () {
	
		//pegando transform dos objs
		ponto01 = GameObject.Find ("Ponto01").GetComponent<Transform> ();
		ponto02 = GameObject.Find ("Ponto02").GetComponent<Transform> ();
		ponto03 = GameObject.Find ("Ponto03").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		//verifica se jogo iniciou
		if (UiManager.instance.ComecouJogo) {
		
			//vector3 para pega posição aleatoria entre dois pontos e passa para ponto3 para criar obj na cena
			Vector3 temp = transform.position;
			temp.x =  Random.Range (ponto01.position.x, ponto02.position.x);
			ponto03.position = temp;

			//condição que verica se tempo para cria obj e menor que 0
			if (intervaloNasce <= 0) {

				GameObject inst = Instantiate (objMorcego, ponto03.position, Quaternion.identity);
				intervaloNasce = 2;
			} else {

				intervaloNasce -= Time.deltaTime;
			}
		}
	}
}
