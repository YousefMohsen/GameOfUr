using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player {
	//List<GameObject> stones;
	// Use this for initialization

	public string name;
	public bool won;
	public string color;
	public int id;

	public Player(string aname, int anId)
	{
		name = aname;
		id = anId;
		setColor (id);
	}
	void Start () {
		won = false;
		//stones = new List<GameObject>();
		//initStones ();
	
	}

	// Update is called once per frame
	void Update () {
	
	}



	void setColor(int ida){
	
		if (ida == 1) {
			color = "black";
		} else if (ida == 2) {
			color = "white";
		}
	
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
