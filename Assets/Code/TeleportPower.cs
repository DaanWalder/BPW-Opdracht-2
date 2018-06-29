using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPower : MonoBehaviour {

	public GameObject ball;
	private RaycastHit hit;
	public Transform cam;
	public float range = 20;
	public AudioClip audioClip;
	// Use this for initialization
	void Start () {
		ball.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
			if (Input.GetButton ("Fire2")) {
			if (Physics.Raycast (cam.position, cam.forward, out hit, range)) {
					ball.transform.position = hit.point;
					ball.SetActive (true);
				}
			} 
			if (Input.GetButtonUp ("Fire2")) {
			if (Physics.Raycast (cam.position, cam.forward, out hit)) {
					transform.position = ball.transform.position;
					ball.SetActive (false);
				if (audioClip != null){
					AudioSource.PlayClipAtPoint(audioClip, transform.position);
				}
				}
			}
	}
}
