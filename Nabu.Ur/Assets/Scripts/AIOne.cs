using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIOne : Player  {// random 




	public AIOne(string aname, int anId):base(aname,anId)
	{

		base.name = "Computer(AIONE)";

		Debug.Log ("AIONE constructer");
	

	}
		



	public override string[] calcMove(int roll, Dictionary<string, string > boardStatus ){
		string[] result = new string[5];
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
		
			 
		if (AiCheckIfAllowed (toField, boardStatus)) {
			result [0] = stone;
			result [1] = toField;
			result [2] = fromField;
			result [3] = "1";//// 1=a move is calculated
		
		
		} else {//if no possible move
		
			result [0] = stone;
			result [1] = toField;
			result [2] = fromField;
			result [3] = "2";///// 2=a no possible move is found
		
		}
			
		

		if (AiCheckIfKillStone (toField,boardStatus)) {
			result [4] = boardStatus [toField];
		
		} else {
			result [4] = "0";
		}
	




		return result;
	}


	public override string findToField (string froField, int roll){
		int nIndex = fieldOrder.IndexOf (froField) + roll;
	//	Debug.Log ("nIndex" + nIndex+"froField: "+froField);
		string toFied = fieldOrder [nIndex];


			return toFied;

	}








}
