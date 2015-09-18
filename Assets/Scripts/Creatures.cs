using UnityEngine;
using System.Collections;

public class Creatures : MonoBehaviour {

	public class Bacteria{
		public int Hp { get; set; }
		public	int Speed { get; set; }
		public int BreedingMeter { get; set; }
		 
		public Bacteria(int hp, int speed){
			Speed=speed;
			Hp=hp;
			BreedingMeter=0;
		}
	}
	
	public class Phagocyte{
		string Type { get; set; }
		int Hp { get; set; }
		int Dmg { get; set; }
		int SwallowSpeed { get; set; }
		int Speed { get; set; }
	}
	
	public class ReproductionArea{
		int Food { get; set; }
	}

}
