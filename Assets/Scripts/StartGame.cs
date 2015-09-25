using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public GameObject BacteriaPrefab;
    public Vector2 FirstBacteriaPosition;

	// Use this for initialization
	void Start () {
		GameObject FirstBacteria;
        FirstBacteria = Instantiate(BacteriaPrefab, FirstBacteriaPosition, Quaternion.identity) as GameObject;
		FirstBacteria.name = "Bacteria";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)) {
			Application.LoadLevel("Menu");
		}
	}
}
