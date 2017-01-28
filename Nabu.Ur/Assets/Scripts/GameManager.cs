using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager   {



	Game game;

	public GameManager(){
		Start ();
	}
	void Start(){


		startGame ();
	
	}
	
	// Update is called once per frame
	void Update () {

	}



	 void startGame(){
		game = new Game(true);//true = against computer , false = 2 players
	
	}


	public Player getCurrentPlayer(){

		return game.currentPlayer;

	}

	public void turnEnded (){



		game.turnEnded ();
	}



	public string[] getComputerMove(){


			return  game.getComputerMove ();//

		//return new string[2]{"white2","B5"};//
	
	}


	public void rollDice  (){

		game.rollDice();


	}

	public int getRoll(){
		return game.getRoll();

	}

	public bool checkIfAllowedMove(string fromField, string toField, int roll){
		return game.checkIfAllowedMove (fromField, toField, roll);
	}


	public bool getPlayerHasRolled(){

		return game.playerHasRolled;
	}


	public void setPlayerHasRolled(bool plHaRo){

		game.setPlayerHasRolled (plHaRo);
	}

	public bool checkIfRosetta(string stoneTag){
	
		return game.checkIfRosetta (stoneTag);
	
	}


	public void updateBoard( string stoneV, string fromFieldK, string ToFieldK){
	
		game.updateBoard (stoneV, fromFieldK, ToFieldK);
	}

	public	string getEnemyColor(){

		return game.getEnemyColor ();
	}


	public void updateKill(string field){
	

		game.updateKill (field);
	}

}
