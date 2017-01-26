using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AITwo : Player {


	public AITwo(string aname, int anId):base(aname,anId)
	{

		base.name = "AIONE";
		Debug.Log ("AIONE constructer");



	}



	public override string[] calcMove(int roll, Dictionary<string, string > boardStatus ){
		string[] result = new string[3];

		result [0] = "white1";
		result [1] = "B5";
		result [2] = "C0";



		//foreach (string s in boardStatus.Values) {
		//
		//}

		Debug.Log ("Computer turn!");

		return result;
	}



}
