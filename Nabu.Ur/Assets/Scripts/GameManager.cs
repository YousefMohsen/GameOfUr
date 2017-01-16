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
		game = new Game();
	
	}


	public Player getCurrentPlayer(){

		return game.currentPlayer;

	}

	public void turnEnded (){



		game.changeCurrentPlayer ();
	}





	void doTjek(){
		
		if (game.player1.won == true || game.player2.won == true) {//1 tjek if anyone has won
			game.finished = true;
		}

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

}
