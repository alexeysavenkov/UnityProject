using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : Collectable {

	protected override void OnRabitHit (HeroController rabit) {
		LivesController.current.AddLife ();
		this.CollectedHide ();
	}
}
