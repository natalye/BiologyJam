using UnityEngine;
using System.Collections;

public class Creatures : MonoBehaviour {

	public class Bacteria{
		int Hp;
		int Speed;
		int BreedingMeter=0;
	}
	
	public class Phagocyte{
		string Type;
		int Hp;
		int Dmg;
		int SwallowSpeed;
		int Speed;
	}
	
	public class BreedingArea{
		int Food;
	}

}
