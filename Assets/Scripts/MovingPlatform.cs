using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public double speed;
	public float pauseTime;
	public Vector3 MoveBy;
	Vector3 pointA;
	Vector3 pointB;

	Rigidbody2D myBody = null;

	void Start () {
		this.pointA = this.transform.position;
		this.pointB = this.pointA + MoveBy;
		myBody = this.GetComponent<Rigidbody2D> ();
	}

	bool hasArrived(Vector3 pos, Vector3 target) {
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance(pos, target) < 0.02f;
	}
		
	bool isPause = false;
	float pauseTimeLeft;
	bool going_to_a = false;

	void Update() {
		if (isPause) {
			pauseTimeLeft -= Time.deltaTime;
			if (pauseTimeLeft <= 0) {
				isPause = false;
			}
			return;
		}

		Vector3 my_pos = this.transform.position;
		Vector3 target;
		if (going_to_a) {
			target = this.pointA;
		} else {
			target = this.pointB;
		}
		if (hasArrived (my_pos, target)) {
			going_to_a = !going_to_a;
			myBody.velocity = Vector3.zero;
			isPause = true;
			pauseTimeLeft = pauseTime;
			return;
		}
		Vector3 destination = target - my_pos;

		float spd = (float)(speed * Time.deltaTime);
		myBody.velocity = destination.normalized;
		myBody.velocity.Scale (new Vector3 (spd, spd, 0));
	}
}
