using UnityEngine;
using System.Collections;

public class _GM : MonoBehaviour {
	public Tile[,] map;

	public class Tile{
		bool legal;
		Unit unit;
		bool altitude;

		public Tile(bool l,bool a){
			legal = l;
			unit = null;
			altitude = a;
		}

		public Tile(Unit u, bool a){
			legal = true;
			unit = u;
			altitude = a;
		}

		public string SayHi(){
			return "I'm a tile!";
		}

		public Unit getUnit(){
			return unit;
		}
	}

	public enum CharClass {Swordsman,Medic,Gunslinger,Sniper,Brawler,Recon};	//These may each be separate classes later, for now they are enum constants.

	[System.Serializable]
	public class Unit {					//All units based on this class, whether they are friends or foes. Universal variables and methods.
		int health;
		CharClass charClass;

		public Unit(){}

		public Unit(int c){				//between 0 and 5, depending on the class's order in line 5.
			health = 100;
			charClass = (CharClass)c;
			Debug.Log (charClass);
		}

		public void sayHi(){
			Debug.Log ("Hi!");
		}
	}

	public class FriendlyUnit : Unit {
		public FriendlyUnit(int c)
			: base (c)
		{
		}
		public void sayHi(){			//Showing that the subclass method overrides the base class method of the same method name.
			Debug.Log ("Hello!");
		}
	}

	public class EnemyUnit : Unit {
		public EnemyUnit(int c)
			: base (c)
		{
		}
	}

	void Start(){
		map = new Tile[16,10];
		for(int u=0;u<map.GetLength(0);u++){
			for(int v=0;v<map.GetLength(1);v++){
				map[u,v]=new Tile(new FriendlyUnit(4),false);
			}
		}
		Debug.Log (map[4,4].SayHi());
		map[6,8].getUnit().sayHi();
	}
}
