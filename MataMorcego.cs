using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MataMorcego : MonoBehaviour {

	//Trigger que mata morcego quando sai de cena
	void OnTriggerEnter2D (Collider2D col ){
	
		if (col.gameObject.CompareTag ("inimigo")) {
		
			Destroy (col.gameObject);
		}
	}
}
