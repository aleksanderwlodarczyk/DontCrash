using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawn : MonoBehaviour {

	public GameObject bgPrefab;

	public void SpawnBG(){
		Instantiate (bgPrefab, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
	}
}
