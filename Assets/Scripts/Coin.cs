﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable {
	protected override void OnRabitHit (HeroController rabit) {
		this.CollectedHide ();
		LevelController.current.addCoin ();
	}
}
