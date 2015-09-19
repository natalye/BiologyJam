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
	

	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log("Collision!");
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

		if (!chosenTarget) {
			if (col.gameObject.name == "ToxicRadius") {
				Debug.Log("Detected Bacteria Close By...");
				chosenTarget = true;
				target = col.gameObject;
			}
		}
		else {
			if (col.gameObject.tag == "Bacteria") {
				chosenTarget = false;
				Debug.Log("Devoured Bacteria!!!");
				hp -= 10;
				Debug.Log ("Eating is hard.. Lost 10 HP. Curent HP = " + hp);
				target = null;
				col.gameObject.SetActive(false);
				randomDirectionChosen = false;
				if (hp <= 0) {
					gameObject.SetActive(false);
					Debug.Log ("Phagocyte is Dead");
				}
			}
		}

	}

	void ChooseRandomDirection() {
		Debug.Log ("Choosing Random Direction...");
		moveDirection = Random.insideUnitCircle;
		moveDirection.x = Mathf.Abs(moveDirection.x);
		moveDirection.Normalize();
		randomDirectionChosen = true;
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
			moveDirection = new Vector2(1.0f, 0);
			moveDirection.Normalize();
		}
		else {
			// start roaming in the lane
			if (!randomDirectionChosen) {
				ChooseRandomDirection();
			}

			if (target) {
				Debug.Log("have target, moving to it");
				// move towards target bacteria
				moveDirection = new Vector2 (target.transform.position.x - gameObject.transform.position.x, target.transform.position.y - gameObject.transform.position.y);
				moveDirection.Normalize();
			}
		}

		// move
		gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + moveDirection * speed * Time.deltaTime;
	}
}
