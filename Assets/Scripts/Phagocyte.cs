using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phagocyte : MonoBehaviour {

	string type { get; set; }
	int hp { get; set; }
	int dmg { get; set; }
	int swallowSpeed { get; set; }
	int speed { get; set; }


	struct LaneBounds {
		public int startX;
		public int endX;
		public int topY;
		public int botY;
	}

	int halfPhagocyteWidth = 35;

	Dictionary<int, LaneBounds> lanes = new Dictionary<int, LaneBounds>();
	int targetLane = 1;
	bool randomDirectionChosen = false;

	Vector2 moveDirection;
	bool chosenTarget = false;
	GameObject target;
	bool inLane = false;

	// Use this for initialization
	void Start () {

		LaneBounds lane = new LaneBounds();
		lane.startX = -740;
		lane.endX = -410;
		lane.topY = 530;
		lane.botY = -530;
		lanes.Add(1, lane);

		hp = 100;
		speed = 200;
	}


	void OnCollisionStay2D (Collision2D col) {
		/*
		//if (col.gameObject.name == "UpperWall" || col.gameObject.name == "BottomWall" || col.gameObject.name == "RightWall" || col.gameObject.name == "LeftWall") {
		if (col.gameObject.name == "Walls") {
			Debug.Log("collided with wall");
			if (inLane) {
				Debug.Log("hit");
				//StartCoroutine(WallHit());
			} else {
				inLane = true;
				//ChooseRandomDirection ();
			}
		}
		*/
	}

	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log ("Collision!");
		if (inLane) {
			if (col.gameObject.name == "TopWall") {
				Debug.Log("Collision: Top Wall");
				moveDirection = new Vector2(moveDirection.x, -moveDirection.y);
			}
			else if (col.gameObject.name == "BottomWall") {
				Debug.Log("Collision: Bottom Wall");
				moveDirection = new Vector2(moveDirection.x, -moveDirection.y);
			}
			else if (col.gameObject.name == "LeftWall") {
				Debug.Log("Collision: Left Wall");
				moveDirection = new Vector2(-moveDirection.x, moveDirection.y);
			}
			else if (col.gameObject.name == "RightWall") {
				Debug.Log("Collision: Right Wall");
				moveDirection = new Vector2(-moveDirection.x, moveDirection.y);
			}
		}
		else {
			// pass through walls until reach target lane
		}

		/*
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
				//ChooseRandomDirection ();
				if (hp <= 0) {
					gameObject.SetActive (false);
					Debug.Log ("phagocyte's dead");
			}
		}
		*/
		/*
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
		*/

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

	/*
	IEnumerator WallHit(){
		//CancelInvoke ("ChooseRandomDirection");
		moveDirection = new Vector2 ((-moveDirection.x), (-moveDirection.y));
		yield return new WaitForSeconds (1);
		ChooseRandomDirection ();
		StopCoroutine("WallHit()");
	}
	*/
	
	private void ChooseRandomDirection()
	{
		Debug.Log ("Choosing Random Direction...");
		moveDirection = Random.insideUnitCircle;
		moveDirection.x = Mathf.Abs(moveDirection.x);
		moveDirection.Normalize();
		//Invoke("ChooseRandomDirection",0.75f);
	}


	// Update is called once per frame
	void Update () {

		if (!inLane) {

			if (gameObject.transform.position.x > lanes[targetLane].startX + halfPhagocyteWidth) {
				// in lane
				inLane = true;
				Debug.Log("Entered Target Lane");
			}

			// move into the lane
			//Debug.Log("moving towards target lane");
			moveDirection = new Vector2(1.0f, 0);
			moveDirection.Normalize();
			gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + moveDirection * speed * Time.deltaTime;
		}
		else {
			// start roaming in the lane
			if (!randomDirectionChosen) {
				moveDirection = new Vector2(1.0f, 1.0f);
				moveDirection.Normalize();
				gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + moveDirection * speed * Time.deltaTime;
				randomDirectionChosen = true;

				//gameObject.GetComponent<Rigidbody2D>().velocity = moveDirection * speed * Time.deltaTime;
				//gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(moveDirection);
				//gameObject.GetComponent<Rigidbody2D>().velocity = speed * moveDirection * Time.deltaTime;

			}
			//Debug.Log("roaming in lane");

			gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + moveDirection * speed * Time.deltaTime;

			/*
			if (target) {
				Debug.Log("have target, moving to it");
				// move towards target bacteria
				moveDirection = new Vector2 (target.transform.position.x - gameObject.transform.position.x, target.transform.position.y - gameObject.transform.position.y);
			}
			*/

		}
	}
}
