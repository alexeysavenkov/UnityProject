using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable {
	public int id;

	bool wasAlreadyCollected;

	void Start() {
		LevelStat levelStat = LevelStat.fromStorage (LevelController.current.level);
		wasAlreadyCollected = levelStat.collectedFruits.Contains (id);
		if(wasAlreadyCollected) {
			SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer> ();
			Color tmp = spriteRenderer.color;
			tmp.a = 0.4f;
			spriteRenderer.color = tmp;
		}
	}

	protected override void OnRabitHit (HeroController rabit) {
		this.CollectedHide ();
		if (!wasAlreadyCollected) {
			LevelController.current.addFruit (id);
		}
	}
}
