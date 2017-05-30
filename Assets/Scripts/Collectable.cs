using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour {

	protected abstract void OnRabitHit (HeroController rabit);

	public bool hideAnimation = false;

	void OnTriggerEnter2D(Collider2D collider) {
		if(!this.hideAnimation) {
			HeroController heroController = collider.GetComponentInParent<HeroController> ();
			if(heroController != null) {
				this.OnRabitHit (heroController);
			}
		}
	}

	public void CollectedHide() {
		Destroy(this.gameObject);
	}
}
