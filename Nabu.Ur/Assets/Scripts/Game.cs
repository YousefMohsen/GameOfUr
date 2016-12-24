using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	Vector2[] board = new Vector2[20]; 
	// Use this for initialization
	Player human;
	void Start () {

		human = new Player ();

		initBoardPosition ();

		Debug.Log (board [0]);
		Debug.Log (board [1]);
		Debug.Log (board [2]);
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}



	public int rollDice  (){//returns a random number between 1 & 4

		var randomNumber= Random.Range (1, 5);
		return randomNumber;


	}

	void initBoardPosition(){
		board [0] = new Vector2 (1, 2);
		board [1] = new Vector2 (1, 3);
		board [2] = new Vector2 (1, 7);
	}



}
