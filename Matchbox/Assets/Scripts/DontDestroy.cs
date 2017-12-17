using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {


	void Awake(){
		
		DontDestroyOnLoad (transform.gameObject);

		if (GameObject.Find ("AudioPlayer") != null && GameObject.Find ("AudioPlayer") != this.gameObject) {
			Destroy (this.gameObject);
		}
	}

}
