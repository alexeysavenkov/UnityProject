using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLevelExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject winPopupPrefab;

	void OnTriggerEnter2D(Collider2D collider) {
		HeroController heroController = collider.GetComponentInParent<HeroController> ();
		if (heroController != null) {
			//Знайти батьківський елемент
			GameObject parent = UICamera.first.transform.parent.gameObject;
			//Створити Prefab
			GameObject obj = NGUITools.AddChild (parent, winPopupPrefab);
			//Отримати доступ до компоненту (щоб передати параметри)
			WinPopup winPopup = obj.GetComponent<WinPopup>();
			//...

			LevelStat levelStat = LevelController.current.getStats ();
			winPopup.setStats (levelStat);

		}
	}
}
