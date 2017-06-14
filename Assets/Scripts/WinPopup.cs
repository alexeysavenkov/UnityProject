using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPopup : MonoBehaviour {

	public GameObject fruitLabel, coinLabel;

	UILabel labelFruit, labelCoins;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject crystalParent;
	public void setStats(LevelStat levelStat) {
		labelFruit = fruitLabel.GetComponent<UILabel> ();
		labelCoins = coinLabel.GetComponent<UILabel> ();
		labelFruit.text = levelStat.collectedFruits.Count + "/" + levelStat.maxFruits;
		labelCoins.text = "+" + levelStat.collectedCoins;

		List<Crystal.Color> crystalColors = levelStat.collectedCrystals;
		for (int i = 0; i < crystalColors.Count; i++) {
			Transform child = crystalParent.transform.GetChild (i);
			UI2DSprite sprite = child.gameObject.GetComponent<UI2DSprite> ();
			switch (crystalColors [i]) {
			case Crystal.Color.Blue:
				sprite.sprite2D = CrystalController.current.crystalBlueSprite;
				break;
			case Crystal.Color.Green:
				sprite.sprite2D = CrystalController.current.crystalGreenSprite;
				break;
			case Crystal.Color.Red:
				sprite.sprite2D = CrystalController.current.crystalRedSprite;
				break;
			}
		}

		HeroController.lastRabit.enabled = false;
	}

	public void onReplayClick() {
		Destroy (this.gameObject);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void onNextClick() {
		Destroy (this.gameObject);
		SceneManager.LoadScene ("MainMenu");
	}
}
