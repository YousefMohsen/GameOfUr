using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour  {

	Game game;
	UIManager uim; //(UIManager)GameObject.FindGameObjectWithTag("Canvas").GetComponent(typeof(UIManager));


	void Start(){
		uim = new UIManager (GameObject.FindGameObjectWithTag ("Canvas"), Camera.main);
		Debug.Log ("start works");
		startGame ();
	
	}
	
	// Update is called once per frame
	void Update () {
		uim.Update ();
	}


	 void startGame(){
		game = new Game();
		uim.setCurrentPlayerLabel (game.currentPlayer.name);
	
	}

	public void printTest(){

	game.printBoardStatus ();
	}



	void player1Turn(){


	
	doTjek();
	}
	void player2Turn(){

	
		doTjek();
	}
	void doTjek(){
		
		if (game.player1.won == true || game.player2.won == true) {//1 tjek if anyone has won
			game.finished = true;
		}
		uim.setCurrentPlayerLabel ("game.currentPlayer.name");
	}



}
