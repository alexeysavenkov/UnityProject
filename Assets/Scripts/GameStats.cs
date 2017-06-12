using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameStats {
	public List<LevelStat> levelStats = new List<LevelStat>();
	public int collectedCoins = 0;

	public void save() {
		string str = JsonUtility.ToJson(this);
		PlayerPrefs.SetString ("stats", str);
	}

	public static GameStats fromStorage() {
		string str = PlayerPrefs.GetString ("stats", null);
		GameStats stats = JsonUtility.FromJson<GameStats> (str);
		if (str == null || stats == null) {
			return new GameStats ();
		}
		return stats;
	}
}
