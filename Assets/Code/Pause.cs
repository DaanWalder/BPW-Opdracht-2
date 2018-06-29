using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenu;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume ();
			} else {
				Paused ();
			}
		}
	}
	public void Resume ()
	{
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void Paused ()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void Restard()
	{
		Debug.Log ("Restarting Game");
		SceneManager.LoadScene (0);
	}

	public void Quit()
	{
		Debug.Log("Quiting Game");
		Application.Quit ();
	}
}