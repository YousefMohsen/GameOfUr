using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager  {

	Game game;
	UIManager uim = (UIManager)GameObject.FindGameObjectWithTag("Canvas").GetComponent(typeof(UIManager));


	public GameManager(){
		startGame ();
		uim.setDiceLabel("messi");

		//uim.setDiceLabel ("launch works!");
	}


	
	// Update is called once per frame
	void Update () {

	}
	 void startGame(){
		game = new Game();

		/*while(game.finished!=true){

			player1Turn();//player1 turn
			doTjek();// do tjek
			player2Turn() ;//player2 turn
			doTjek();//do tjek

		}*/
	
	
	
	}

	public void printTest(){

	game.printBoardStatus ();
	}



	void player1Turn(){


	}
	void player2Turn(){
	}
	void doTjek(){
		if (game.player1.won == true || game.player2.won == true) {//1 tjek if anyone has won
			game.finished = true;
		}
	}


	public void p1StoneLanded(string fieldName){
	
		game.p1StoneLanded (fieldName);
	}
	public void p2StoneLanded(string fieldName){

		game.p2StoneLanded (fieldName);
	}

}
