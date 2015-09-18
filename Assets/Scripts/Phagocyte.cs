using UnityEngine;
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
	
	// Use this for initialization
	void Start () {
		hp = 100;
		speed = 300;
	}


	void OnCollisionEnter2D (Collision2D col) {
		if (!chosenTarget) {
			if (col.gameObject.name == "ToxicRadius") {
				chosenTarget = true;
				Debug.Log ("detected bacteria");
				target = col.gameObject;
			}
		}
		else {
			if (col.gameObject.name == "Bacteria") {
				chosenTarget = false;
				Debug.Log ("devoured bacteria");
				target = null;
				col.gameObject.SetActive(false);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (target) {
			moveDirection = new Vector2(target.transform.position.x - gameObject.transform.position.x, target.transform.position.y - gameObject.transform.position.y);
			moveDirection.Normalize();
		}
		else {
			moveDirection = new Vector2(1.0f, 0);
			moveDirection.Normalize();
		}

		gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + moveDirection * speed * Time.deltaTime;
	}
}
