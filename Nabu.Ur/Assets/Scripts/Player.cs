using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player {
	//List<GameObject> stones;
	// Use this for initialization

	public string name;
	public bool won;

	public Player(string aname)
	{
		name = aname;
	}
	void Start () {
		won = false;
		//stones = new List<GameObject>();
		//initStones ();
	
	}

	// Update is called once per frame
	void Update () {
	
	}



	
	
	
	//} 

	void initStones(){//delete
		
		Debug.Log (GameObject.Find ("Canvas").GetComponentsInChildren<GameObject> ().Length);
		foreach (GameObject gObject in GameObject.Find ("Canvas").GetComponentsInChildren<GameObject>()) {
			if (gObject.tag.Contains("black1")) {
				Debug.Log (gObject.tag);
				//stones.Add (gObject);
			}
		}
	
	}
}
