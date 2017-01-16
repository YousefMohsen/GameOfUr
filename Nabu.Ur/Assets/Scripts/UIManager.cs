using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {
	private static Text diceLabel;
	private static Text currentPLabel;
	GameObject selectedStone;
	GameObject fromField;
	GameManager gm;
	//GameObject[] whites = new GameObject[5];
	Vector3[] stonePositions = new Vector3[5];

	GameObject black3;
	// Use this for initialization




	void Start () {
		
		gm = new GameManager();
		diceLabel = returnLabelWithTag ("diceLabel");
		currentPLabel = returnLabelWithTag ("currentPlayer");

	

		initStonePositions ();

		setCurrentPlayerLabel(gm.getCurrentPlayer().name );
			

	

	}
	
	// Update is called once per frame
	public void Update () {
		

		if (Input.touchCount > 0) {
			Debug.Log ("touchType"+Input.GetTouch (0).position.GetType());
		selectStone ();
	selectedStoneStatus ();


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
		RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll (Camera.main.ScreenPointToRay ((Input.GetTouch (0).position)), 100);
		RaycastHit2D hit;

		if (hits.Length == 0) {//if no objects touched
			highlightStoneOFF (selectedStone);
			selectedStone = null;
		} else if (hits.Length == 1) {//if hit a field OR a stone
			hit = hits [0];
			Debug.Log("length = 1 !!");
			Debug.Log("fromField: "+fromField.tag);
			if (hit.collider.tag.Contains (gm.getCurrentPlayer ().color)) {//i stone

				highlightStoneOFF (selectedStone);
				selectedStone = hit.transform.gameObject;
				highlightStone (selectedStone);



			} else if (selectedStone != null && hit.collider.tag.Length == 2 && Input.GetTouch (0).phase == TouchPhase.Ended) {//if a stone i selected and a field touched

				moveStone (hit.collider.gameObject,fromField,getRoll());
			}

		} else if (hits.Length == 2) {//if hit a field AND a stone
			RaycastHit2D stone = findStoneFromArray (hits);
			RaycastHit2D field = findFieldFromArray (hits);
			if (selectedStone != null && stone.collider.tag.Contains (getEnemyColor (gm.getCurrentPlayer ().color))) {//if there is an enemy stone on the field
				//		stone.transform.position = white1.transform.position;

				killStone (stone.transform.gameObject);
		
				moveStone (field.collider.gameObject,fromField,getRoll());

			
			
			
			} else if (stone.collider.tag.Contains (gm.getCurrentPlayer ().color)) {//if there is one of my stones on the field
			
				fromField = field.collider.gameObject;
				highlightStoneOFF (selectedStone);
				selectedStone = stone.transform.gameObject;
				highlightStone (selectedStone);
			}


		} else {//to delete
			Debug.Log ("ERROR! more than 2 hits!");
			Debug.Log ("number of hits: "+hits.Length+": ");

			foreach(RaycastHit2D ahit in hits){

				Debug.Log (ahit.collider.tag+": "+ahit.collider.transform.position);
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
		Debug.Log ("roll" + roll);
		Debug.Log ("moveFrom" + moveFrom.tag);
		Debug.Log ("moveTo" + moveTo.tag);
		if(gm.checkIfAllowedMove(moveFrom.tag, moveTo.tag,roll)){

		Debug.Log("MOVESTONE "+ moveTo.tag );
		selectedStone.transform.position = moveTo.transform.position;
		highlightStoneOFF(selectedStone);
		selectedStone = null;
		gm.turnEnded ();
		setCurrentPlayerLabel(gm.getCurrentPlayer().name );
		}
	}



	string getEnemyColor(string currentPlayerColor){

		if (currentPlayerColor.Equals ("white")) {
			return "black";
		} else if (currentPlayerColor.Equals ("black")) {
		
			return "white";
		} else {
			return null;
		}


	}
	void selectedStoneStatus(){//delete me
	

	
		if (selectedStone == null) {
			setDiceLabel ("no selected stone");
		}
		else{
			setDiceLabel (selectedStone.tag);
		}
	}

	void killStone(GameObject killedSton){
	
		if (killedSton.tag.Contains("black")) {//if black stone i skilled
			Vector3 temp = stonePositions [int.Parse( (killedSton.tag.Substring(5)))-1];
			temp.x = stonePositions [int.Parse( (killedSton.tag.Substring(5)))-1].x * (-1.0F);
					killedSton.transform.position = temp;
			} else {//if white stone i skilled

			killedSton.transform.position = stonePositions [int.Parse( (killedSton.tag.Substring(5)))-1];
		
			}
	}

	void initStonePositions(){
		stonePositions [0] = new Vector3 (2.2F, -3.9F, 90.0F);
		stonePositions [1] = new Vector3 (2.2F, -2.6F, 90.0F);
		stonePositions [2] = new Vector3 (2.2F, -3.2F, 90.0F);
		stonePositions [3] = new Vector3 (2.2F, -1.4F, 90.0F);
		stonePositions [4] = new Vector3 (2.2F, -2.0F, 90.0F);
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
		gm.rollDice();
	}


	public int getRoll(){
		return gm.getRoll();

	}








































}