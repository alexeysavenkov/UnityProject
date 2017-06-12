using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLevelSelect : MonoBehaviour {

	public int levelToSelect;

	void OnTriggerEnter2D(Collider2D collider) {
		if (levelToSelect == 1 || LevelStat.fromStorage (levelToSelect - 1).levelPassed)
			SceneManager.LoadScene ("Level" + levelToSelect);
	}
}
