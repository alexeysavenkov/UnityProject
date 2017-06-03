using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Bomb {

	public float speed = 5;

	void Start() {
		StartCoroutine (destroyLater ());
	}

	IEnumerator destroyLater() {
		yield return new WaitForSeconds (3.0f);
		Destroy (this.gameObject);
	}

	public void launch(Vector2 direction) {
		Rigidbody2D myBody = this.GetComponent<Rigidbody2D> ();

		Vector3 pos = this.transform.position;

		myBody.velocity = direction.normalized * speed;

		if (direction.x >= 0) {
			this.transform.position += new Vector3 (1, 1, 0);
		} else {
			this.transform.position += new Vector3 (1, -1, 0);
		}
	}
}
