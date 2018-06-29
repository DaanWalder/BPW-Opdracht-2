using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	public GameObject ThePlayer;
	public float TargetDistance;
	public float AllowedRange = 20;
	public GameObject TheEnemy;
	public float EnemeySpeed;
	public int AttackTrigger;
	public RaycastHit Shot;
	public int HitTrigger;
	private static int Health = 100;

	public int IsAttacking;
	public GameObject ScreenFlash;
	public AudioClip AttackSound;

	void Update(){
		transform.LookAt (ThePlayer.transform);
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out Shot)) {
			TargetDistance = Shot.distance;
			if (TargetDistance < AllowedRange) {
				EnemeySpeed = 0.10f;
				if (AttackTrigger == 0) {
					transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, EnemeySpeed);
				}
			} else {
				EnemeySpeed = 0;
			}
		}
		if (AttackTrigger == 1) {
			if (IsAttacking == 0) {
				StartCoroutine (EnemyDamage ());
				EnemeySpeed = 0;
			}
		}
	}
	void OnCollisionEnter(Collision collision){
		GameObject bullet = collision.gameObject;
		Health -= 10;
		if (Health <= 0) {
			Destroy (gameObject);
			ScreenFlash.SetActive (false);
		}
		Destroy (bullet);
	}
	void OnTriggerEnter(Collider col){
		switch (col.tag) {
		case "Player":
			AttackTrigger = 1;
			break;
		}
	}
	void OnTriggerExit(Collider col){
		switch (col.tag) {
		case "Player":
			AttackTrigger = 0;
			break;
		}
	}
		

	IEnumerator EnemyDamage(){
		IsAttacking = 1;
		AudioSource.PlayClipAtPoint(AttackSound, transform.position);
		ScreenFlash.SetActive (true);
		GlobalHealth.PlayerHealth -= 10;
		yield return new WaitForSeconds (1.7f);
		ScreenFlash.SetActive (false);
		yield return new WaitForSeconds (1.7f);
		IsAttacking = 0;
	}
}
