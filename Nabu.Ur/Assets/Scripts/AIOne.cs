using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIOne : Player  {// random 




	public AIOne(string aname, int anId):base(aname,anId)
	{

		base.name = "Computer(AIONE)";

		Debug.Log ("AIONE constructer");
	
		stonesOnBoard.Add("white1");
		stonesOnBoard.Add("white2");
		stonesOnBoard.Add("white3");
	}
		



	public override string[] calcMove(int roll, Dictionary<string, string > boardStatus ){
		string[] result = new string[3];
		Dictionary<string, string > maStones = findMyStones (boardStatus);

		//1) find stone
		string stone = ""; //= stonesOnBoard[Random.Range(0,stonesOnBoard.Count)];
		string fromField="";// = findFieldOfStone(stone,boardStatus);
		string toField="";//= findToField (fromField, roll);


		NonGen.Shuffle (myStones);
		foreach (string myStone in myStones) {
			stone = myStone;
			fromField = findFieldOfStone(stone,boardStatus);
			toField = findToField (fromField, roll);
			if(AiCheckIfAllowed(toField, boardStatus)){

				break;
			}
		
		
		}
		
			 
			
			
		


		result [0] = stone;
		result [1] = toField;
		result [2] = fromField;




		return result;
	}


	public override string findToField (string froField, int roll){
		int nIndex = fieldOrder.IndexOf (froField) + roll;
		Debug.Log ("nIndex" + nIndex+"froField: "+froField);
		string toFied = fieldOrder [nIndex];


			return toFied;

	}








}
