using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public MyButton playButton;

	// Use this for initialization
	void Start () {
		playButton.signalOnClick.AddListener (this.onPlayClick);
	}
	
	// Update is called once per frame
	public void onPlayClick () {
		SceneManager.LoadScene ("LevelSelect");
		Application.Quit ();
	}

	public void onSettingsClick () {
		SceneManager.LoadScene ("LevelSelect");
	}
}
