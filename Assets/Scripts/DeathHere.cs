using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHere : MonoBehaviour {
	//Стандартна функція, яка викличеться,
	//коли поточний об’єкт зіштовхнеться із іншим
	void OnTriggerEnter2D(Collider2D collider) {
		//Намагаємося отримати компонент кролика
		HeroController obj = collider.GetComponentInParent<HeroController> ();

		//Впасти міг не тільки кролик
		if (obj != null) {
			Debug.Log (obj.name);
			//Повідомляємо рівень, про смерть кролика
			LevelController.current.onRabitDeath (obj.gameObject);
		}
	}
}
