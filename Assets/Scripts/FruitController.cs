using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour {

	public static FruitController current;

	void Awake() {
		current = this;
	}
	// Use this for initialization
	void Start () {
		

		UILabel label = this.GetComponentInChildren<UILabel> ();
		label.text = "0/" + fruitLimit;
	}

	int fruitsCount;
	public int fruitLimit = 11;

	public void updateUI(int fruitsN) {
		this.fruitsCount = fruitsN;

	}
	
	// Update is called once per frame
	void Update () {
		UILabel label = this.GetComponentInChildren<UILabel> ();
		label.text = fruitsCount + "/" + fruitLimit;
	}
}
