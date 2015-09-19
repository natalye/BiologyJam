﻿using UnityEngine;
using System.Collections;

public class Phagocyte : MonoBehaviour {

	string type { get; set; }
	int hp { get; set; }
	int dmg { get; set; }
	int swallowSpeed { get; set; }
	int speed { get; set; }


	Vector2 moveDirection;
	bool chosenTarget = false;
	GameObject target;
	bool inLane= false;

	// Use this for initialization
	void Start () {
		hp = 100;
		speed = 200;
	}


	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log ("colide");
		if (!chosenTarget) {
			Debug.Log ("colide2");
			if (col.gameObject.name == "ToxicRadius") {
				Debug.Log (" pre detected bacteria");
				chosenTarget = true;
				Debug.Log ("detected bacteria");
				target = col.gameObject;
			}
		} else {
			if (col.gameObject.tag == "Bacteria") {
				chosenTarget = false;
				Debug.Log ("devoured bacteria");
				hp -= 10;
				Debug.Log (hp);
				target = null;
				col.gameObject.SetActive (false);
				ChooseRandomDirection ();
				if (hp <= 0) {
					gameObject.SetActive (false);
					Debug.Log ("phagocyte's dead");
				}
			}
		}
		Debug.Log ("preif");
		if (col.gameObject.name == "UpperWall" || col.gameObject.name == "BottomWall" || col.gameObject.name == "RightWall" || col.gameObject.name == "LeftWall") {
			Debug.Log ("prehit");
			if (inLane) {
				Debug.Log ("hit");
				//moveDirection = new Vector2 ((-moveDirection.x), (-moveDirection.y));
				StartCoroutine (WallHit ());

			}
			else
			{
				inLane = true;
				moveDirection = Random.insideUnitCircle;
				moveDirection.x = Mathf.Abs (moveDirection.x);
				moveDirection.Normalize ();
			}
		}

		/*if (col.gameObject.name == "Walls") {
			Debug.Log ("colide");
			if (inLane == true) {

			} else {
				ChooseRandomDirection ();
				inLane = true;
				Debug.Log ("in lane");
			}
		}*/
		
	}

	IEnumerator WallHit(){
		//CancelInvoke ("ChooseRandomDirection");
		moveDirection = new Vector2 ((-moveDirection.x), (-moveDirection.y));
		yield return new WaitForSeconds (1);
		ChooseRandomDirection ();
		StopCoroutine("WallHit()");
	}
		
	private void ChooseRandomDirection()
	{
		Debug.Log ("random");
		moveDirection = Random.insideUnitCircle;
		moveDirection.Normalize ();
		//Invoke("ChooseRandomDirection",0.75f);
	}

	// Update is called once per frame
	void Update () {
		if (target) {
			//CancelInvoke();
			moveDirection = new Vector2 (target.transform.position.x - gameObject.transform.position.x, target.transform.position.y - gameObject.transform.position.y);
			moveDirection.Normalize ();
		} else {
			if (!inLane) {
				moveDirection = new Vector2 (1.0f, 0);
				moveDirection.Normalize ();
			}
		}

		gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + moveDirection * speed * Time.deltaTime;
	}
}
