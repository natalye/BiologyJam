using UnityEngine;
using System.Collections;

public class PhagoButton : MonoBehaviour {

	public GameObject phagocytePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
		GameObject newPhagocyte;
		Vector2 position = new Vector2(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y);
		newPhagocyte = Instantiate(phagocytePrefab, position, Quaternion.identity) as GameObject;
	}

}
