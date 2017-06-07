using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable {
	protected override void OnRabitHit (HeroController rabit) {
		this.CollectedHide ();
		LevelController.current.addFruits (1);
	}
}
