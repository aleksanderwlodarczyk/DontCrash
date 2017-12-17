using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {


	private bool steering = false;
	private int direction_int;
	private float playerTurnSpeed_s = 10f;
	private float modelTurnSpeed_s = 5.7142f;
	private Quaternion startRot;
	private float score;
	private GameObject highscoreText;


	[HideInInspector]
	public float obstacleSpeed = 10f;
	public bool stop = false;
	public float wait;

	private float playerTurnSpeed;
	private float modelTurnSpeed;

	public float bound;

	private GameObject GameOverImage;

	void Start () {
		playerTurnSpeed = playerTurnSpeed_s;
		modelTurnSpeed = modelTurnSpeed_s;
		startRot = gameObject.transform.rotation;

		GameOverImage = GameObject.Find ("GameOverImage");
		GameOverImage.SetActive (false);

		highscoreText = GameObject.Find ("highscoreText");
		highscoreText.SetActive (false);

		//PlayerPrefs.SetInt ("instruction", 0);

	}

	void Update () {
		//if (Input.GetTouch (0).phase != TouchPhase.Began) {
		//	steering = false;
		//}



		/*if (Input.touchCount == 0 && steering) {
			steering = false;
			playerTurnSpeed = playerTurnSpeed_s;
			modelTurnSpeed = modelTurnSpeed_s;

		}*/

		if (stop) {
			steering = false;

		} else {
			score += 0.1f * obstacleSpeed;
			obstacleSpeed += 0.001f;
			GameObject.Find ("scoreText").GetComponent<Text> ().text = Mathf.RoundToInt (score).ToString ();
		}

		if (score > 50 && wait > 0.5f) {
			wait -= 0.0001f * (score / 50);
		}

		if (steering && !stop) {
			float rotacja = gameObject.transform.rotation.eulerAngles.z;
			if (rotacja > 300f) {
				rotacja -= 360;
			}
			//Debug.Log (gameObject.transform.rotation.eulerAngles.z);
			
			if ((rotacja > bound && direction_int == -1) || (rotacja < -bound && direction_int == 1) || (Mathf.Abs(rotacja) < bound)) {
				
				gameObject.transform.parent.gameObject.transform.Rotate (0f, 0f, Time.deltaTime * 20f * direction_int * playerTurnSpeed);
				gameObject.transform.Rotate (0f, 0f, Time.deltaTime * 20f * -direction_int * modelTurnSpeed);

				if (playerTurnSpeed <= 22.54592f) {
					
					playerTurnSpeed += (playerTurnSpeed * 0.005f);
					modelTurnSpeed += (modelTurnSpeed * 0.005f);
				}


			}
		
		}
	}

	public void Steer(string direction){

		if (direction == "left") {
			direction_int = -1;
		} else {
			direction_int = 1;
		}

		steering = true;
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "obstacle") {
			coll.gameObject.GetComponent<ObstacleMover> ().hitted = true;
			GameOver ();
		}

	}

	void GameOver(){
		GameOverImage.SetActive (true);
		stop = true;
		GameObject.Find ("ObstacleSpawner").GetComponent<ObstacleSpawn> ().spawn = false;

		GameObject.Find ("scoreText").GetComponent<Animator> ().SetBool ("stop", stop);

		int highscore = PlayerPrefs.GetInt ("highscore");

		if (Mathf.RoundToInt (score) > highscore) {
			highscore = Mathf.RoundToInt(score);
			PlayerPrefs.SetInt("highscore", Mathf.RoundToInt(score));
		}

		highscoreText.SetActive (true);
		highscoreText.GetComponent<Text> ().text = highscore.ToString();
		highscoreText.GetComponent<Animator> ().SetBool ("stop", stop);

	}
}
