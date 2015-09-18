using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Creatures.Bacteria test = new Creatures.Bacteria (5, 30);
		Debug.Log (test.Hp + "" + test.Speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
