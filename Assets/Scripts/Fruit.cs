using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable {
	public int id;

	protected override void OnRabitHit (HeroController rabit) {
		this.CollectedHide ();
		LevelController.current.addFruit (id);
	}
}
