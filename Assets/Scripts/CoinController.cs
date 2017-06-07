using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	public static CoinController current;

	// Use this for initialization
	void Start () {
		current = this;
	}

	public void updateUI(int coinsN) {
		string text = coinsN.ToString();
		while (text.Length < 4) {
			text = "0" + text;
		}

		UILabel label = this.GetComponentInChildren<UILabel> ();
		label.text = text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
