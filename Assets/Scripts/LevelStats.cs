using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelStat {
	

	public bool levelPassed = false;

	public List<int> collectedFruits = new List<int>();
	public int maxFruits;
	public bool hasAllFruits = false;

	public int collectedCoins;

	public List<Crystal.Color> collectedCrystals;
	public bool hasAllCrystals = false;
}
