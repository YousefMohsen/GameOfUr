using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	UIManager ui;
	Game newGame;
	Player human; 	
	// Use this for initialization
	void Start () {
		ui = new UIManager ();
		newGame = new Game();
		human = new Player ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void rollDice(){

	ui.setDiceLabel ("Throwed: "+newGame.rollDice ());
	}



}
