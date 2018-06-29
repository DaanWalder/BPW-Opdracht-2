using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		switch (col.tag) {
		case "Player":
			Destroy (gameObject);
			SceneManager.LoadScene (0);
			break;
		}
	}
}
