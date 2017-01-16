using UnityEngine;
using System.Collections;
using System.Collections.Generic;





public class Game  {
	public Player player1;
	public Player player2;
	public Player currentPlayer;
	public bool finished = false;
	public bool playerHasRolled = false;
	public int roll;


	Dictionary<string, int > boardStatus = new Dictionary<string, int>();
	List<string> p1FieldOrder = new List<string>();
	List<string> p2FieldOrder = new List<string>();
	List<string> rosettaFields = new List<string>();


	public Game(){
		initField ();
		player1 = new Player ("Gudea",1);
		player2 = new Player ("Nabu",2);
		currentPlayer = player1;
		Debug.Log ("checkIfAllowedMove: " + checkIfAllowedMove ("C1", "B3", 3));
		roll = 3;
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




	void initField(){

		// player 1
		p1FieldOrder.Add( "A0");// unplayed
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
		p1FieldOrder.Add( "C0");// unplayed
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
		// add finishline



		///rosettaFields
		rosettaFields.Add("A1");
		rosettaFields.Add("C1");
		rosettaFields.Add("B4");
		rosettaFields.Add("A7");
		rosettaFields.Add("C7");
	}



	public bool checkIfAllowedMove(string fromField, string toField, int roll){
		List<string> fieldOrder;
		int newInex;

		if (currentPlayer.id == 1) {
			fieldOrder = p1FieldOrder;
		} else {
			fieldOrder = p2FieldOrder;
		
		}
		newInex = fieldOrder.IndexOf (fromField) + roll; 
		if (fieldOrder [newInex].Equals (toField)) {
		
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
		playerHasRolled = false;

	}



	public void rollDice  (){

		roll = Random.Range (1, 5);

	
	}

	public int getRoll(){
		return roll;
	
	}


	public bool getPlayerHasRolled(){
	
		return playerHasRolled;
	}


	public void setPlayerHasRolled(bool plHaRo){

		playerHasRolled=plHaRo;
	}


	public bool checkIfRosetta(string stoneTag){
	
		foreach (string f in rosettaFields) {
			if (stoneTag.Equals (f)) {
				return true;
			}
		
		}
		return false;
	
	}

}
