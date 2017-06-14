using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {

	public static LivesController current;

	public Sprite emptyHeart;
	public Sprite fullHeart;

	// Use this for initialization
	void Start () {
		current = this;
		livesLeft = 3;
	}

	public int livesLeft;

	public void onRabitDeath() {
		livesLeft--;
		int childrenCnt = transform.childCount;
		for (int i = 0; i < childrenCnt; i++) {
			Transform child = transform.GetChild (i);
			UI2DSprite sprite = child.gameObject.GetComponent<UI2DSprite> ();
			if (sprite.sprite2D != emptyHeart) {
				sprite.sprite2D = emptyHeart;
				break;
			}
		}
	}

	public void AddLife() {
		if (livesLeft != 3) {
			livesLeft++;
			int childrenCnt = transform.childCount;
			for (int i = childrenCnt - 1; i >= 0; i--) {
				Transform child = transform.GetChild (i);
				UI2DSprite sprite = child.gameObject.GetComponent<UI2DSprite> ();
				if (sprite.sprite2D == emptyHeart) {
					sprite.sprite2D = fullHeart;
					break;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
