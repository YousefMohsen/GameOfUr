using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
	private static Text corner;
	private static Text currentPLabel;
	private static Text diceLabel;//to delete
	GameObject selectedStone;
	GameObject fromField;
	GameManager gm;
	//GameObject[] whites = new GameObject[5];
	Vector3[] stonePositions = new Vector3[6];

	GameObject white1;
	GameObject A2;
	// Use this for initialization




	void Start () {
		
		gm = new GameManager();
		diceLabel = returnLabelWithTag ("diceLabel");
		currentPLabel = returnLabelWithTag ("currentPlayer");
	
		white1 = GameObject.FindGameObjectWithTag ("white1");
		A2 = GameObject.FindGameObjectWithTag ("C2");

		initStonePositions ();

		//setCurrentPlayerLabel(gm.getCurrentPlayer().name );
			
	//	for (int i = 1; i < 7; i++) {
	//		black3 = GameObject.FindGameObjectWithTag ("black" + i);
	//		Debug.Log (black3.tag + " " + black3.transform.position);
		
//		}
	

	}
	
	// Update is called once per frame
	public void Update () {
		

		if (Input.touchCount > 0) {
			
		selectStone ();
			Debug.Log ("selectedStone!! " + selectedStone.tag);

		}


	}

	public void setDiceLabel(string str){
	diceLabel.text = str;


	}
	public void setCurrentPlayerLabel(string str){
		currentPLabel.text = str;


	}

	//hits = Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition),100);
	// player controller 

	void selectStone(){
		//onnly if player1s turn
		//RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint ((Input.GetTouch (0).position)), Vector2.zero);

		if (gm.getPlayerHasRolled() ) { //if player has throwed dice 

			RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll (Camera.main.ScreenPointToRay ((Input.GetTouch (0).position)), 100);
			RaycastHit2D hit;

			if (hits.Length == 0) {//if no objects touched
				highlightStoneOFF (selectedStone);
				selectedStone = null;
			} else if (hits.Length == 1) {//if hit a field OR a stone
				hit = hits [0];
//				Debug.Log ("length = 1 !!");
//				Debug.Log ("fromField: " + fromField.tag);
				if (hit.collider.tag.Contains (gm.getCurrentPlayer ().color)) {//i stone

					highlightStoneOFF (selectedStone);
					selectedStone = hit.transform.gameObject;
					highlightStone (selectedStone);



				} else if (selectedStone != null && hit.collider.tag.Length == 2 && Input.GetTouch (0).phase == TouchPhase.Ended) {//if a stone i selected and a field touched

					moveStone (hit.collider.gameObject, fromField, gm.getRoll ());
				}

			} else if (hits.Length == 2) {//if hit a field AND a stone
				RaycastHit2D stone = findStoneFromArray (hits);
				RaycastHit2D field = findFieldFromArray (hits);
				if (selectedStone != null && stone.collider.tag.Contains (getEnemyColor ())) {//if there is an enemy stone on the field
					//		stone.transform.position = white1.transform.position;

					if(gm.checkIfRosetta(field.collider.tag)!=true){//if enemy is not on a rosetta field
					killStone (stone.transform.gameObject);
		
					moveStone (field.collider.gameObject, fromField, gm.getRoll ());
					}

			
			
			
				} else if (stone.collider.tag.Contains (gm.getCurrentPlayer ().color)) {//if there is one of my stones on the field
			
					fromField = field.collider.gameObject;
					highlightStoneOFF (selectedStone);
					selectedStone = stone.transform.gameObject;
					highlightStone (selectedStone);
				}


			} else {//to delete
				Debug.Log ("ERROR! more than 2 hits!");
				Debug.Log ("number of hits: " + hits.Length + ": ");

				foreach (RaycastHit2D ahit in hits) {

					Debug.Log (ahit.collider.tag + ": " + ahit.collider.transform.position);
				}
			}






		}
	}

	void highlightStone(GameObject stone){
		if (stone != null) {
		Behaviour halo = (Behaviour)stone.GetComponent ("Halo");
		halo.enabled = true;

		}
	}
		
	void highlightStoneOFF(GameObject stone){
		if (stone != null) {
			Behaviour halo = (Behaviour)stone.GetComponent ("Halo");
			halo.enabled = false;
			
		}
	}

	string returnFieldOfStone(Vector3 stonePosition){//delete
		RaycastHit2D hit  = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((stonePosition)), Vector2.zero);
		return hit.collider.tag;

	}






	void moveStone(GameObject moveTo, GameObject moveFrom,int roll){
	//	Debug.Log ("roll" + roll);
	//	Debug.Log ("moveFrom" + moveFrom.tag);
	//	Debug.Log ("moveTo" + moveTo.tag);
		if(gm.checkIfAllowedMove(moveFrom.tag, moveTo.tag,roll)){

	//	Debug.Log("MOVESTONE "+ moveTo.tag );
		selectedStone.transform.position = moveTo.transform.position;
		highlightStoneOFF(selectedStone);
		
		//update board
			gm.updateBoard(selectedStone.tag,moveFrom.tag, moveTo.tag);


		selectedStone = null;
	
		
			if (gm.checkIfRosetta (moveTo.tag)) {//check if landen on rosetta field
				gm.setPlayerHasRolled (false);

			} else {
				gm.turnEnded ();
				setCurrentPlayerLabel(gm.getCurrentPlayer().name );
				if (gm.getCurrentPlayer ().isHuman == false) { computerTurn ();}
			}
		
		
		}
	}


	void AIMove(){





	}


	public	string getEnemyColor(){

		return gm.getEnemyColor ();
	}


	void killStone(GameObject killedSton){
	
		if (killedSton.tag.Contains("black")) {//if black stone i skilled
			int index = int.Parse( (killedSton.tag.Substring(5)))-1;
			Debug.Log ("index " + index);
			Vector3 temp = stonePositions [index];
			temp.x = stonePositions [int.Parse( (killedSton.tag.Substring(5)))-1].x * (-1.0F);
					killedSton.transform.position = temp;
			} else {//if white stone i skilled

			killedSton.transform.position = stonePositions [int.Parse( (killedSton.tag.Substring(5)))-1];
		//updateBoard
			}
	}

	void initStonePositions(){
		stonePositions [0] = new Vector3 (2.2F, -2.7F, 90.0F);
		stonePositions [1] = new Vector3 (2.2F, -3.3F, 90.0F);
		stonePositions [2] = new Vector3 (2.2F, -2.1F, 90.0F);
		stonePositions [3] = new Vector3 (2.2F, -1.6F, 90.0F);
		stonePositions [4] = new Vector3 (2.2F, -3.8F, 90.0F);
		stonePositions [5] = new Vector3 (2.2F, -4.3F, 90.0F);
	}

	Text returnLabelWithTag(string tag){

		foreach (Text textElement in GameObject.FindGameObjectWithTag ("Canvas").GetComponentsInChildren<Text>()) {
			if (tag.Equals(textElement.tag)) {
				return textElement;
			}
		}
		return null;

	}

	RaycastHit2D findStoneFromArray(RaycastHit2D[] hitsList){
	foreach (RaycastHit2D gm in hitsList) {
			if (gm.collider.tag.Length==6) {
				return gm;
			}
		}
		return new RaycastHit2D();
	}


	RaycastHit2D findFieldFromArray(RaycastHit2D[] hitsList){
		foreach (RaycastHit2D gm in hitsList) {
			if (gm.collider.tag.Length<4) {
				return gm;
			}
		}
	return new RaycastHit2D();
	}		


	public void rollDice(){
		//if (gm.getPlayerHasRolled() == false) {
			Debug.Log ("257 getPlayerHasRolled");
			gm.rollDice ();
			setDiceLabel (gm.getRoll () + " ");
			gm.setPlayerHasRolled (true);
		//}
	}

	void computerTurn(){
		if(!gm.getCurrentPlayer().isHuman){//only if currentplayer is computer
			string[] compMoves = gm.getComputerMove();
			GameObject stone = GameObject.FindGameObjectWithTag(compMoves[0]); 
			GameObject toField = GameObject.FindGameObjectWithTag(compMoves[1]); 
	
		
			Debug.Log (stone.tag+" "+stone.transform.position);
			Debug.Log (toField.tag+" "+toField.transform.position);

			highlightStone (stone);
			
			stone.transform.position = toField.transform.position;
			highlightStoneOFF (stone);

			gm.turnEnded ();


		}
	}











































}