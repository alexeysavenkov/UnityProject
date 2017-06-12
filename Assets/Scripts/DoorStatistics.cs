using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStatistics : MonoBehaviour {

	public int level;
	public GameObject check, crystal, fruit, doorLock;
	public Sprite crystalFilled, fruitFilled;

	// Use this for initialization
	void Start () {
		LevelStat levelStat = LevelStat.fromStorage (level);

		if (level == 1 || LevelStat.fromStorage (level - 1).levelPassed) {
			Destroy (doorLock);
		}

		if (!levelStat.levelPassed) {
			Destroy (check);
		}

		if (levelStat.hasAllFruits) {
			SpriteRenderer fruitRenderer = fruit.GetComponent<SpriteRenderer> ();
			fruitRenderer.sprite = fruitFilled;
		}

		if (levelStat.hasAllCrystals) {
			SpriteRenderer crystalRenderer = crystal.GetComponent<SpriteRenderer> ();
			crystalRenderer.sprite = crystalFilled;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
