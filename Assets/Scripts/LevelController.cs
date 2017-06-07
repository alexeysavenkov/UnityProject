using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public static LevelController current;

	// Use this for initialization
	void Awake () {
		current = this;

	}

	Vector3 startingPosition;
	public void setStartPosition(Vector3 pos) {
		this.startingPosition = pos;
	}
	public void onRabitDeath(GameObject rabit) {
		//При смерті кролика повертаємо на початкову позицію
		rabit.transform.position = this.startingPosition;
		coins = 0;
		if (LivesController.current != null) {
			LivesController.current.onRabitDeath ();
		}
	}

	private int coins = 0;
	public void addCoins(int n) {
		coins += n;
		if (CoinController.current != null) {
			CoinController.current.updateUI (coins);
		}
	}
}
