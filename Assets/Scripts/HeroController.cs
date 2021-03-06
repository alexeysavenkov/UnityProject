﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

	public AudioClip attackSound, walkSound, dieSound;
	public AudioSource attackSoundSource, walkSoundSource, dieSoundSource;

	public float speed = 1;
	bool isGrounded = false;
	bool JumpActive = false;
	float JumpTime = 0f;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;

	public bool isDisabled = false;


	public Rigidbody2D myBody = null;
	SpriteRenderer sr = null;
	Animator animator = null;
	Transform heroParent = null;

	public static HeroController lastRabit = null;
	void Awake() {
		lastRabit = this;
	}

	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator> ();
		heroParent = this.transform.parent;

		LevelController.current.setStartPosition (transform.position);


		attackSoundSource = gameObject.AddComponent<AudioSource> ();
		attackSoundSource.clip = attackSound;

		walkSoundSource = gameObject.AddComponent<AudioSource> ();
		walkSoundSource.clip = walkSound;

		dieSoundSource = gameObject.AddComponent<AudioSource> ();
		dieSoundSource.clip = dieSound;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDisabled) {
			if (!isDying) {
				UpdateMove ();
				UpdateGrounded ();
				UpdateJump ();
			} else {
				UpdateDie ();
			}
		}
	}

	void UpdateMove() {
		float value = Input.GetAxis ("Horizontal");

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
			animator.SetBool ("run", true);
		} else {
			animator.SetBool ("run", false);
		}

		if(value < 0) {
			sr.flipX = true;
		} else if(value > 0) {
			sr.flipX = false;
		}
	}

	void UpdateGrounded() {
		//class HeroRabit, void FixedUpdate()
		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");
		//Перевіряємо чи проходить лінія через Collider з шаром Ground
		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
		if(hit) {
			isGrounded = true;
			if(hit.transform != null
				&& hit.transform.GetComponent<MovingPlatform>() != null){
				//Приліпаємо до платформи
				SetNewParent(this.transform, hit.transform);
			}
		} else {
			isGrounded = false;
			SetNewParent(this.transform, this.heroParent);
		}
		//Намалювати лінію (для розробника)
		Debug.DrawLine (from, to, Color.red);
	}

	static void SetNewParent(Transform obj, Transform new_parent) {
		if(obj.transform.parent != new_parent) {
			//Засікаємо позицію у Глобальних координатах
			Vector3 pos = obj.transform.position;
			//Встановлюємо нового батька
			obj.transform.parent = new_parent;
			//Після зміни батька координати кролика зміняться
			//Оскільки вони тепер відносно іншого об’єкта
			//повертаємо кролика в ті самі глобальні координати
			obj.transform.position = pos;
		}
	}

	void UpdateJump() {
		if(Input.GetButtonDown("Jump") && isGrounded) {
			this.JumpActive = true;
		}
		if(this.JumpActive) {
			//Якщо кнопку ще тримають
			if(Input.GetButton("Jump")) {
				this.JumpTime += Time.deltaTime;
				if (this.JumpTime < this.MaxJumpTime) {
					Vector2 vel = myBody.velocity;
					vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
					myBody.velocity = vel;
				}
			} else {
				this.JumpActive = false;
				this.JumpTime = 0;
			}
		}
			
		if(this.isGrounded) {
			animator.SetBool ("jump", false);
		} else {
			animator.SetBool ("jump", true);
		}
	}

	private void UpdateDie () {
		
		if (isDying) {
			timeLeftToDie -= Time.deltaTime;
			if (timeLeftToDie <= dieAnimationTime / 2) {
				animator.SetBool ("die", false);
			}
			if (timeLeftToDie <= 0) {
				isDying = false;

				LevelController.current.onRabitDeath (this.gameObject);
			}
		}
	}

	public float dieAnimationTime = 1;
	float timeLeftToDie;
	bool isDying = false;


	public void Die() {
		if (isDying) {
			return;
		}
			
		if (this.isGrounded) {
			isDying = true;
			//animator.SetBool ("die", true);
			animator.Play("DieAnimation");
			if (SoundManager.Instance.isSoundOn ()) {
				dieSoundSource.Play ();
			}
			timeLeftToDie = dieAnimationTime;
		} else {
			LevelController.current.onRabitDeath (this.gameObject);
		}
	}

	bool isBig;
	public bool IsBig
	{
		get 
		{ 
			return isBig; 
		}
		set 
		{
			if (value) {
				this.transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
			} else {
				this.transform.localScale = new Vector3 (1, 1, 1);
			}
			isBig = value;
		}
	}
}
