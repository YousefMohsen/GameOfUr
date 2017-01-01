using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class Game  {
	public Player player1;
	public Player player2;
	public bool finished = false;


	Dictionary<string, int > boardStatus = new Dictionary<string, int>();


	public Game(){
		initField ();
		player1 = new Player ("Gilgamesh");
		player2 = new Player ("Nabu");
	}
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
	
	}










	public int rollDice  (){//returns a random number between 1 & 4

		var randomNumber= Random.Range (1, 5);
		return randomNumber;


	}

	void initField(){
		boardStatus.Add("A1", 0);
		boardStatus.Add("A2", 0);
		boardStatus.Add("A3", 0);
		boardStatus.Add("A4", 0);
		boardStatus.Add("A7", 0);
		boardStatus.Add("A8", 0);

		boardStatus.Add("B1", 0);
		boardStatus.Add("B2",0);
		boardStatus.Add("B3", 0);
		boardStatus.Add("B4",0);
		boardStatus.Add("B5", 0);
		boardStatus.Add("B6",0);
		boardStatus.Add("B7",0);
		boardStatus.Add("B8", 0);

		boardStatus.Add("C1", 0);
		boardStatus.Add("C2", 0);
		boardStatus.Add("C3", 0);
		boardStatus.Add("C4", 0);
		boardStatus.Add("C7", 0);
		boardStatus.Add("C8", 0);
	}

	public void p1StoneLanded(string fieldName){
		boardStatus [fieldName] = 1;
	}
	public void p2StoneLanded(string fieldName){
		boardStatus [fieldName] = 1;
	}

	public void printBoardStatus(){ //to delete

		Debug.Log("!!!! BoardStatus !!!!:");

		foreach (string k in boardStatus.Keys )
		{

			Debug.Log(k+ " - "+boardStatus[k]);
		}
		Debug.Log("------------");
	
	}



}
