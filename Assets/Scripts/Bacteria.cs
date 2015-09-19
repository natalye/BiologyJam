using UnityEngine;
using System.Collections;

public class Bacteria : MonoBehaviour {
	public GameObject BacteriaPrefab;
	public int Hp { get; set; }
	public	int Speed { get; set; }
	public float BreedingMeter { get; set; }
	public float breedingspeed = 1;
	public bool InRPArea;
	public GameObject TargetRPArea;
	public Bacteria(int hp, int speed){
		Speed=speed;
		Hp=hp;
		BreedingMeter=0;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (BreedingMeter < 10) {
			BreedingMeter += breedingspeed * Time.deltaTime;
		} else {
			BreedingMeter=0;
			Reproduction();
		}
	}


	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "ReproductionArea") {
			breedingspeed=2.5f;
			InRPArea=true;
			TargetRPArea=col.gameObject;
		}
	}
	
	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "ReproductionArea") {
			breedingspeed=1;
			InRPArea=false;
			TargetRPArea=null;
		}
	}


	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.tag == "ReproductionArea") {
			breedingspeed=2.5f;
			InRPArea=true;
			TargetRPArea=col.gameObject;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.tag == "ReproductionArea") {
			breedingspeed=1;
			InRPArea=false;
			TargetRPArea=null;
		}
	}

	private void Reproduction() {
		GameObject NewBacteria;
		//Vector2 position = new Vector2 (900, 0);
		Vector2 position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
		NewBacteria = Instantiate (BacteriaPrefab, position, Quaternion.identity) as GameObject;
		NewBacteria.name = "Bacteria";
		if (InRPArea == true) {
		}
	}
}
