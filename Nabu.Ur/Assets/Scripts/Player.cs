using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Player {
	//List<GameObject> stones;
	// Use this for initialization

	public string name;
	public bool won;
	public string color;
	public int id;
	public bool isHuman;
	public List<string> fieldOrder = new List<string>();
	List<string> rosettaFields = new List<string>();

	public List<string> myStones;// for AIs
	public List<string> stonesOnBoard = new List<string>();// for AIs

	public Player(string aname, int anId)
	{

		name = aname;
		id = anId;
		setColor (id);
		isHuman = true;
		won = false;

		if (id == 1) {
			initP1Fields ();
		} else if (id == 2) { //if id==2
			initP2Fields ();
		} else {// if id == 3, AI
			isHuman = false;	
			myStones = new List<string> ();
			initP2Fields ();
			initMyStones ();
			initRosetta ();
		}
	
	
	

	
	}







	void setColor(int ida){
	
		if (ida == 1) {
			color = "black";
		} else if (ida == 2 || ida==3) {
			color = "white";
		}
	
	}
	
	
	//} 

	void initStones(){//delete
		
		Debug.Log (GameObject.Find ("Canvas").GetComponentsInChildren<GameObject> ().Length);
		foreach (GameObject gObject in GameObject.Find ("Canvas").GetComponentsInChildren<GameObject>()) {
			if (gObject.tag.Contains("black1")) {
				Debug.Log (gObject.tag);
				//stones.Add (gObject);
			}
		}
	
	}





	void initP1Fields (){

		// player 1
		fieldOrder.Add( "A0");// unplayed
		fieldOrder.Add( "A4");
		fieldOrder.Add("A3");
		fieldOrder.Add("A2");
		fieldOrder.Add( "A1");
	

		fieldOrder.Add("B1");
		fieldOrder.Add("B2");
		fieldOrder.Add("B3");
		fieldOrder.Add("B4");
		fieldOrder.Add("B5");
		fieldOrder.Add("B6");
		fieldOrder.Add("B7");
		fieldOrder.Add("B8");


		fieldOrder.Add("A8");
		fieldOrder.Add("A7");
		fieldOrder.Add("A9");

	}
	void initP2Fields (){
		// player 2 
		fieldOrder.Add( "C0");// unplayed
		fieldOrder.Add( "C4");
		fieldOrder.Add("C3");
		fieldOrder.Add("C2");
		fieldOrder.Add( "C1");

		fieldOrder.Add("B1");
		fieldOrder.Add("B2");
		fieldOrder.Add("B3");
		fieldOrder.Add("B4");
		fieldOrder.Add("B5");
		fieldOrder.Add("B6");
		fieldOrder.Add("B7");
		fieldOrder.Add("B8");


		fieldOrder.Add("C8");
		fieldOrder.Add("C7");
		fieldOrder.Add("C9");
		// add finishline

	}
	public bool checkIfAllowedMove(string fromField, string toField, int roll){

		int newInex;


		newInex = fieldOrder.IndexOf (fromField) + roll; 
		if(newInex>=15 && toField.Equals(fieldOrder[15])) {
			return true;
		} else if (fieldOrder [newInex].Equals (toField)) {

			return true;
		} else {
			return false;
		}



	}
		

	////////////// AI 
	public virtual string[] calcMove(int roll, Dictionary<string, string > boardStatus ){


		return new string[3];
	}

	public string findFieldOfStone(string aStone, Dictionary<string, string> aBoard){
	
		foreach (string k in aBoard.Keys) {
		
			if (aBoard [k].Equals (aStone)) {

				return k;
			}
		}
		return "C0";
	
	}
	public	string getEnemyColor(){

		if (color.Equals ("white")) {
			return "black";
		} else if (color.Equals ("black")) {

			return "white";
		} else {
			return null;
		}


	}

	public virtual string findToField(string froField, int roll){
	
		return " ";
	}

	public void initMyStones(){
		myStones.Add (color + 1);
		myStones.Add (color + 2);
		myStones.Add (color + 3);
		myStones.Add (color + 4);
		myStones.Add (color + 5);
		myStones.Add (color + 6);

	}

	public 	Dictionary<string, string > findMyStones(Dictionary<string, string > board){

		Dictionary<string, string > myStones = new Dictionary<string, string > ();

		foreach ( KeyValuePair<string, string> pair in board) {

			if (pair.Value.Contains (color)) {


				myStones.Add (pair.Key,pair.Value);
			}



		}

		return myStones;
	}

	public bool AiCheckIfAllowed(string field, Dictionary<string, string > board){

	

		if (board [field].Length < 3 || (board [field].Contains (getEnemyColor()) && checkIfRosetta(field) == false)) {



			return true;
		} else {
			return false;
		}
	}


			public bool checkIfRosetta(string stoneTag){

				foreach (string f in rosettaFields) {
					if (stoneTag.Equals (f)) {
						return true;
					}

				}
				return false;

			}
			void initRosetta(){



				///rosettaFields
				rosettaFields.Add("A1");
				rosettaFields.Add("C1");
				rosettaFields.Add("B4");
				rosettaFields.Add("A7");
				rosettaFields.Add("C7");


			}

	//


	//


	public void ShoufleListTest(){

		foreach (string s in myStones) {
			Debug.Log (s);
		}


		NonGen.Shuffle (myStones);
		Debug.Log ("list shoulfed");

		foreach (string s in myStones) {
			Debug.Log (s);
		}
	}
	///////// AI 





}
