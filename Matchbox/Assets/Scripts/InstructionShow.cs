using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionShow : MonoBehaviour {

	public List<GameObject> instructions;

	void Start () {
		if (PlayerPrefs.GetInt ("instruction") == 1) {
			Destroy (gameObject);
		} else {
			GameObject.Find ("player").transform.GetChild (0).gameObject.GetComponent<PlayerManager> ().stop = true;
			StartCoroutine (ShowInstructions ());
		}
	}


	IEnumerator ShowInstructions(){
		instructions [0].SetActive (true);
		yield return new WaitForSeconds (7f);
		instructions [0].SetActive (false);
		instructions [1].SetActive (true);
		yield return new WaitForSeconds (3f);
		instructions [1].SetActive (false);

		GameObject.Find ("player").transform.GetChild (0).gameObject.GetComponent<PlayerManager> ().stop = false;
		PlayerPrefs.SetInt ("instruction", 1);
		Destroy (gameObject);
	}



}
