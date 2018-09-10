using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

	public GameObject wallPrefab;

	private int num = 100;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < num; i++) {
			GameObject wall = (GameObject)Instantiate (wallPrefab);
			wall.transform.SetParent (gameObject.transform,false);
			wall.transform.position = new Vector3 (0,0,0.5f*i);
		}
	}
}
