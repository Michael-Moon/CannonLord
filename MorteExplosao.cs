using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteExplosao : MonoBehaviour {

	[SerializeField]private float tempo = 1.2f;
	
	// Update is called once per frame
	void Update () {

		//condição que verificar se tempo menor que 0, para destruir particul system
		tempo -= Time.deltaTime;
		if (tempo <= 0) {
		
			Destroy (this.gameObject);
		}
	}
}
