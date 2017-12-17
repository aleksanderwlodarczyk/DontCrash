using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	public void LoadScene(int index){
		if (SceneManager.GetActiveScene().buildIndex == 1 && index == 0) {
			Destroy(GameObject.Find ("AudioPlayer"));
		}
		SceneManager.LoadScene (index);
	}

	public void Exit(){
		Application.Quit ();
	}

}
