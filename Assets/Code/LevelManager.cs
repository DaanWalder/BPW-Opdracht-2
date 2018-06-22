using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public GameObject obstaclePrefab;

	private List<GameObject> obstacles;

	// Use this for initialization
	void Start () {
		obstacles = new List<GameObject> ();
		for (int i = 0; i < 100; ++i) {
			GameObject obstacle = Instantiate (obstaclePrefab, new Vector3 (i*2, 0, 170), Quaternion.identity);
			obstacles.Add (obstacle);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
