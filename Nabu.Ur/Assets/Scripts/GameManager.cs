using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager   {

	Game game;

	public GameManager(){
		Start ();
	}
	void Start(){

		Debug.Log ("start works");
		startGame ();
	
	}
	
	// Update is called once per frame
	void Update () {

	}



	 void startGame(){
		game = new Game();
	
	}

	public void printTest(){

	game.printBoardStatus ();
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



}
