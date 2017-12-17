using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

	private float minX;
	private float maxX;
	private float xPos;
	private int spawnIndex;
	private Vector3 spawnPos;

	[HideInInspector]
	public bool spawn;

	private float wait;
	public List<GameObject> toSpawn;

	void Start () {
		minX = -2.8f;
		maxX = 2.8f;
		spawn = true;

		StartCoroutine (RandomSpawn ());
	}
		
	
	IEnumerator RandomSpawn(){
		while (true) {

			if (!spawn) {
				StopAllCoroutines ();
				break;
			}

			xPos = Random.Range (minX, maxX);
			spawnPos = new Vector3 (xPos, gameObject.transform.position.y, 0f);
			spawnIndex = Random.Range (0, toSpawn.Count);

			if(!GameObject.Find ("player").transform.GetChild(0).GetComponent<PlayerManager> ().stop)
				Instantiate (toSpawn [spawnIndex], spawnPos, gameObject.transform.rotation, gameObject.transform);



			yield return new WaitForSeconds (wait);

			wait = GameObject.Find ("player").transform.GetChild(0).GetComponent<PlayerManager> ().wait;

		}
	}

}
