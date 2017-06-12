using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelStat {
	
	public int level;

	public bool levelPassed = false;

	public List<int> collectedFruits = new List<int>();
	public int maxFruits = -1;
	public bool hasAllFruits = false;

	public int collectedCoins = 0;

	public List<Crystal.Color> collectedCrystals = new List<int>();
	public bool hasAllCrystals = false;

	public void save() {
		GameStats gameStats = GameStats.fromStorage ();

		for(int i = gameStats.levelStats.Count; i < level; i++) {
			gameStats.levelStats.Add (new LevelStat { level = i + 1 });
		}

		gameStats.levelStats[level] = this;
		gameStats.collectedCoins += this.collectedCoins;

		gameStats.save ();
	}

	public static LevelStat fromStorage(int level) {
		GameStats gameStats = GameStats.fromStorage ();

		if (gameStats.levelStats.Count >= level) {
			return gameStats.levelStats [level - 1];
		} else {
			LevelStat newStat = new LevelStat {
				level = level
			};

			return newStat;
		}
	}
}
