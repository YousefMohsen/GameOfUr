using UnityEngine;
using System.Collections;
using System.Collections.Generic;





public class Game  {
	public Player player1;
	public Player player2;
	public Player currentPlayer;
	public bool finished = false;


	Dictionary<string, int > boardStatus = new Dictionary<string, int>();
	List<string> p1FieldOrder = new List<string>();
	List<string> p2FieldOrder = new List<string>();

	public Game(){
		initField ();
		player1 = new Player ("Gudea",1);
		player2 = new Player ("Nabu",2);
		currentPlayer = player2;
		Debug.Log ("checkIfAllowedMove: " + checkIfAllowedMove ("C1", "B3", 3));
	}
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
	
	}


	void runGame(){

	

			player1Turn ();//player1 turn

			player2Turn ();//player2 turn



	}

	void player1Turn(){
		currentPlayer = player2;
	}

	void player2Turn(){
		currentPlayer = player1;

	}


	public int rollDice  (){//returns a random number between 1 & 4

		var randomNumber= Random.Range (1, 5);
		return randomNumber;


	}

	void initField(){

		// player 1

		p1FieldOrder.Add( "A4");
		p1FieldOrder.Add("A3");
		p1FieldOrder.Add("A2");
		p1FieldOrder.Add( "A1");

		p1FieldOrder.Add("B1");
		p1FieldOrder.Add("B2");
		p1FieldOrder.Add("B3");
		p1FieldOrder.Add("B4");
		p1FieldOrder.Add("B5");
		p1FieldOrder.Add("B6");
		p1FieldOrder.Add("B7");
		p1FieldOrder.Add("B8");


		p1FieldOrder.Add("A8");
		p1FieldOrder.Add("A7");


		// player 2 
	
		p2FieldOrder.Add( "C4");
		p2FieldOrder.Add("C3");
		p2FieldOrder.Add("C2");
		p2FieldOrder.Add( "C1");

		p2FieldOrder.Add("B1");
		p2FieldOrder.Add("B2");
		p2FieldOrder.Add("B3");
		p2FieldOrder.Add("B4");
		p2FieldOrder.Add("B5");
		p2FieldOrder.Add("B6");
		p2FieldOrder.Add("B7");
		p2FieldOrder.Add("B8");


		p2FieldOrder.Add("C8");
		p2FieldOrder.Add("C7");


	}



	public bool checkIfAllowedMove(string currentField, string moveToField, int roll){
		List<string> fieldOrder;
		int newInex;

		if (currentPlayer.id == 1) {
			fieldOrder = p1FieldOrder;
		} else {
			fieldOrder = p2FieldOrder;
		
		}
		newInex = fieldOrder.IndexOf (currentField) + roll; 
		if (fieldOrder [newInex].Equals (moveToField)) {
		
			return true;
		} else {
			return false;
		}



				}




	public void changeCurrentPlayer(){
		if (currentPlayer == player1) {
			currentPlayer = player2;
		} else {
			currentPlayer = player1;
		
		}
	

	}

}
