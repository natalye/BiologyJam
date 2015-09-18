using UnityEngine;
using System.Collections;

public class Bacteria : MonoBehaviour {

	public int Hp { get; set; }
	public	int Speed { get; set; }
	public int BreedingMeter { get; set; }
	
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
	
	}
}
