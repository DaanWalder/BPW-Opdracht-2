using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	void Start () 
	{
		StartCoroutine(MoveCamera ());
	}

	private IEnumerator MoveCamera()
	{
		yield return new WaitForSeconds (1.0f);
		while (transform.position.x < 160.0f) 
		{
				transform.position += new Vector3 (10.0f * Time.deltaTime, .0f, .0f);
				yield return 0;
		}
		while (transform.position.x > .0f) {
			transform.position += new Vector3 (-10.0f * Time.deltaTime, .0f, .0f);
			yield return 0;
		}
	}
	void Update () 
	{
		
	}
}
