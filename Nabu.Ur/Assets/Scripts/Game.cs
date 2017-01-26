using UnityEngine;
using System.Collections;
using System.Collections.Generic;





public class Game  {
	public Player player1;
	public Player player2;
	//public AI computer;
	public Player currentPlayer;
	public bool finished = false;
	public bool playerHasRolled = false;
	public int roll;
	public bool againstComputer;


	Dictionary<string, string > boardStatus = new Dictionary<string, string>();
//	List<string> p1FieldOrder = new List<string>();
//	List<string> p2FieldOrder = new List<string>();
	List<string> rosettaFields = new List<string>();


	public Game(bool aganstComputerv){
		roll = 1;
		againstComputer = aganstComputerv;
		initBoardStatus ();
	//	deleteMe();
		player1 = new Player ("Gudea",1);
		currentPlayer = player1;


	if (againstComputer) {//play against AI
		player2 = new AIOne ("doesnt matter",3);
	

	} else {//play against human
			player2 = new Player ("Nabu",2);
		}




	
	//	deleteMe ();
	//	Debug.Log("checkIfAllowedMove"+currentPlayer.checkIfAllowedMove("A1","B2",2));
	//	Debug.Log("checkIfAllowedMove"+currentPlayer.checkIfAllowedMove("B3","B6",3));
	//	Debug.Log("checkIfAllowedMove"+currentPlayer.checkIfAllowedMove("A1","B4",2));
		//Debug.Log("checkIfAllowedMove"+currentPlayer.checkIfAllowedMove("B4","C7",6));
	//	Debug.Log ("Ai: " + Ai.name);
	//	Debug.Log ("Ai: " + Ai.isHuman);
	//	Debug.Log ("p1: " + player1.name);
	//	Debug.Log ("p1: " + player1.isHuman);
		//roll = 4;


	}
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
	
	}






	void initBoardStatus(){

		boardStatus.Add ("A1", "");
		boardStatus.Add ("A2", "");
		boardStatus.Add ("A3", "");
		boardStatus.Add ("A4", "");
		boardStatus.Add ("A7", "");
		boardStatus.Add ("A8", "");


		boardStatus.Add ("B1", "white1");
		boardStatus.Add ("B2", "");
		boardStatus.Add ("B3", "white5");
		boardStatus.Add ("B4", "black2");
		boardStatus.Add ("B5", "");
		boardStatus.Add ("B6", "");
		boardStatus.Add ("B7", "");
		boardStatus.Add ("B8", "");


		boardStatus.Add ("C1", "");
		boardStatus.Add ("C2", "");
		boardStatus.Add ("C3", "");
		boardStatus.Add ("C4", "");
		boardStatus.Add ("C7", "");
		boardStatus.Add ("C8", "");
	
	
	
	
	}



	public bool checkIfAllowedMove(string fromField, string toField, int roll){

		return currentPlayer.checkIfAllowedMove (fromField, toField, roll);

	}




	 void changeCurrentPlayer(){



		if (currentPlayer == player1) {
			currentPlayer = player2;
		} else {
			currentPlayer = player1;
		
		}


	}

	void checkWin(){

		if (player1.won == true || player2.won == true) {//1 tjek if anyone has won
				finished = true;
			}

		
	}

	public void turnEnded(){
	
		checkWin ();
	
		changeCurrentPlayer ();
	}

	public void rollDice  (){

		roll =	Random.Range (1, 5); //roll = Random.Range (1, 5);
		Debug.Log (roll+" roll from Game.cs");
	
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
	void initRosetta(){



		///rosettaFields
		rosettaFields.Add("A1");
		rosettaFields.Add("C1");
		rosettaFields.Add("B4");
		rosettaFields.Add("A7");
		rosettaFields.Add("C7");


	}



	/// boardStatus
	public void updateBoard( string stoneV, string fromFieldK, string ToFieldK){

		if (isValid (ToFieldK)) {//of toField is not c0, c9,A9 or A0

			if (boardStatus.ContainsValue (stoneV)) {//if moved stone is on board
				boardStatus [fromFieldK] = "";//empty from field
				boardStatus [ToFieldK] = stoneV;//set stone on toField
		
			} else {//if stone isnt alredy on board
		
				boardStatus [ToFieldK] = stoneV;
			}
		} else {//if toField is c0, c9,A9 or A0 , then only reset fromField
			boardStatus [fromFieldK] = "";//empty from field
		
		
		}



	} 

	bool isValid(string toField){
	
		if (toField.Equals ("A0") || toField.Equals ("A9") || toField.Equals ("C0") || toField.Equals ("C9")) {
			return false;
		
		} else {

			return true;
		}
	}

	void deleteMe(){


	}
	//	foreach( string s




	public string[] getComputerMove(){
		rollDice ();
		string[] computerMoves	= player2.calcMove (roll, boardStatus);
		string stone = computerMoves [0];
		string toField = computerMoves [1];
		string froField = computerMoves [2];
		updateBoard (stone, froField, toField);




		return new string[2] {stone, toField};



	}

	public	string getEnemyColor(){

		return currentPlayer.getEnemyColor ();
	}
}
