using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {

	public static LivesController current;

	public Sprite emptyHeart;

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
	
	// Update is called once per frame
	void Update () {
		
	}
}
