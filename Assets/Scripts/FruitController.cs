using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour {

	public static FruitController current;

	// Use this for initialization
	void Start () {
		current = this;

		UILabel label = this.GetComponentInChildren<UILabel> ();
		label.text = "0/" + fruitLimit;
	}

	public int fruitLimit = 11;

	public void updateUI(int fruitsN) {
		UILabel label = this.GetComponentInChildren<UILabel> ();
		label.text = fruitsN + "/" + fruitLimit;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
