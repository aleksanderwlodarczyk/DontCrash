using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	public string tagToDestroy;

	void OnTriggerEnter2D(Collider2D other){

		Debug.Log (other.gameObject.tag);
		
		if (other.gameObject.tag == tagToDestroy) {

			if (other.gameObject.tag == "background") {
				GameObject.Find ("bgSpawner").GetComponent<BgSpawn> ().SpawnBG ();
			}

			Destroy (other.gameObject);
		}



	}
	

}
