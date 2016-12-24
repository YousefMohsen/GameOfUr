using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {
	//List<GameObject> stones;
	// Use this for initialization
	void Start () {
		Debug.Log ("init player");
		//stones = new List<GameObject>();
		initStones ();
	
	}

	// Update is called once per frame
	void Update () {
	
	}


	//public Vector2 getMove(int dice){
	
	
	
	//} 

	void initStones(){
		
		Debug.Log (GameObject.Find ("Canvas").GetComponentsInChildren<GameObject> ().Length);
		foreach (GameObject gObject in GameObject.Find ("Canvas").GetComponentsInChildren<GameObject>()) {
			if (gObject.tag.Contains("black1")) {
				Debug.Log (gObject.tag);
				//stones.Add (gObject);
			}
		}
	
	}
}
