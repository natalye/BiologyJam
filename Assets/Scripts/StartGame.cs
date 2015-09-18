using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public GameObject BacteriaPrefab;
	// Use this for initialization
	void Start () {
		GameObject FirstBacteria;
		Vector2 position = new Vector2 (900, 0);
		FirstBacteria = Instantiate (BacteriaPrefab, position, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
