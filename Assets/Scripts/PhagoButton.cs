using UnityEngine;
using System.Collections;

public class PhagoButton : MonoBehaviour {

	public GameObject phagocytePrefab;
	int countPhago = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
		GameObject newPhagocyte;
		Vector2 position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		newPhagocyte = Instantiate(phagocytePrefab, position, Quaternion.identity) as GameObject;
		newPhagocyte.name = "Phagocyte" + countPhago.ToString();
	}

}
