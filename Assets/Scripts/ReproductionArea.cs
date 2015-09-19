using UnityEngine;
using System.Collections;

public class ReproductionArea : MonoBehaviour {

	public float Food { get; set; }
	public int numofbacteria { get; set; }
	// Use this for initialization
	void Start () {
		numofbacteria = 0;
		Food = 300;
	}
	
	// Update is called once per frame
	void Update () {
		Food -=numofbacteria * Time.deltaTime;
	}
	void OnCollisionEnter2D (Collision2D col) {
	if (col.gameObject.tag == "Bacteria") {
			numofbacteria++;
		}
	}

	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "Bacteria") {
			numofbacteria--;
		}	
	}
}

