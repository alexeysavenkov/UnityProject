﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {
	protected override void OnRabitHit (HeroController rabit) {
		if (rabit.IsBig) {
			rabit.IsBig = false;
		} else {
			rabit.Die ();
		}
		this.CollectedHide ();
	}
}
