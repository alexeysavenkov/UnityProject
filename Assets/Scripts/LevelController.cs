using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	public int level;
	public static LevelController current;
	public GameObject loosePopupPrefab;

	public AudioClip music = null;
	AudioSource musicSource = null;

	// Use this for initialization
	void Awake () {
		//PlayerPrefs.DeleteAll();
		current = this;

		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.clip = music;
		musicSource.loop = true;
		if (PlayerPrefs.GetInt ("music", 1) == 1) {
			musicSource.Play ();
		}

		if (level > 0) {
			LevelStat levelStat = LevelStat.fromStorage (level);
			this.fruits = new HashSet<int> (levelStat.collectedFruits);

		}
		this.globalCoins = GameStats.fromStorage ().collectedCoins;

	}

	void Start() {
		if(FruitController.current != null)
			FruitController.current.updateUI (fruits.Count);
	}

	public void toggleMusic(bool enable) {
		PlayerPrefs.SetInt ("music", enable ? 1 : 0);
		if (enable) {
			musicSource.Play ();
		} else {
			musicSource.Stop ();
		}
	}

	Vector3 startingPosition;
	public void setStartPosition(Vector3 pos) {
		this.startingPosition = pos;
	}
	public void onRabitDeath(GameObject rabit) {
		if (LivesController.current != null) {
			LivesController.current.onRabitDeath ();
		}

		if (SceneManager.GetActiveScene().name == "LevelSelect" || LivesController.current.livesLeft > 0) {
			//При смерті кролика повертаємо на початкову позицію
			rabit.transform.position = this.startingPosition;
		} else {
			coins = 0;
			//Знайти батьківський елемент
			GameObject parent = UICamera.first.transform.parent.gameObject;
			//Створити Prefab
			GameObject obj = NGUITools.AddChild (parent, loosePopupPrefab);
			LoosePopup loosePopup = obj.GetComponent<LoosePopup> ();
		}
	}

	private int globalCoins;
	private int coins = 0;
	public void addCoin() {
		coins ++;
		if (CoinController.current != null) {
			CoinController.current.updateUI (coins);
		}
	}

	private HashSet<int> fruits = new HashSet<int>();
	public void addFruit(int fruitId) {
		fruits.Add(fruitId);
		if (FruitController.current != null) {
			FruitController.current.updateUI (fruits.Count);
		}
	}

	private List<Crystal.Color> crystals = new List<Crystal.Color>();
	public void addCrystal(Crystal.Color color) {
		this.crystals.Add (color);
		if (CrystalController.current != null) {
			CrystalController.current.updateUI (crystals);
		}
	}

	public GameObject settingsPrefab;
	public GameObject popupParent;

	public void showSettings() {
		//Знайти батьківський елемент
		GameObject parent = UICamera.first.transform.parent.gameObject;
		//Створити Prefab
		GameObject obj = NGUITools.AddChild (parent, settingsPrefab);
		//Отримати доступ до компоненту (щоб передати параметри)
		SettingsPopUp popup = obj.GetComponent<SettingsPopUp>();
		//...
	}

	public LevelStat getStats() {
		LevelStat res = new LevelStat {
			level = level,
			levelPassed = true,
			collectedFruits = new List<int>(fruits),
			maxFruits = FruitController.current.fruitLimit,
			hasAllFruits = fruits.Count >= FruitController.current.fruitLimit,
			collectedCoins = coins,
			collectedCrystals = crystals,
			hasAllCrystals = crystals.Count >= 3
		};

		return res;
	}

}
