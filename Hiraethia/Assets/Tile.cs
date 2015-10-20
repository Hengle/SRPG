using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	public _GM.FriendlyUnit unit;
	public _GM.CharClass charClass;
	// Use this for initialization
	void Start () {
		//charClass = _GM.CharClass.Medic;
		unit = new _GM.FriendlyUnit((int)charClass);
		unit.sayHi();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
