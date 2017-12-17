using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour {

	private float scrollSpeed;
	private PlayerManager playerM;

	[HideInInspector]
	public bool hitted;

	void Start () {
		playerM = GameObject.Find ("player").transform.GetChild(0).GetComponent<PlayerManager> ();
		hitted = false;

	}
	

	void Update () {
		if (!playerM.stop) {
			scrollSpeed = playerM.obstacleSpeed;
			transform.Translate (-Vector3.up * Time.deltaTime * scrollSpeed);
		}

		if (hitted && gameObject.name.Substring(0,4) == "cone") {
			gameObject.GetComponent<Rigidbody2D> ().AddForce(Vector2.up*(scrollSpeed * scrollSpeed)/2.5f);
			gameObject.GetComponent<Rigidbody2D> ().AddTorque (scrollSpeed/2);

		}

	}
}
